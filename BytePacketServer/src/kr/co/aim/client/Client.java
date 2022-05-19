package kr.co.aim.client;

import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;
import java.util.Scanner;

import kr.co.aim.server.Packet;

/*
	에코 클라이언트
	- 서버에 메시지를 보내고, 해당 메시지를 돌려 받을 것.
 */
public class Client {
	private Socket client;
	private InputStream in;
	private OutputStream out;
	private Scanner scanner;
	
	private String name;
	private String ip;
	private int port;
	
	/*
		생성자 정의
		1. accessServer 메소드 호출
		2. if문 클라이언트가 null이 아닌지? 
			> setClient 메소드
			> communicate 메소드 호출
			> close 메소드 호출
	 */
	public Client() {
		accessServer();
		
		if(client != null) {
			registerClient();
			run();
		}
	}

	/*
		accessServer; 서버 접근을 위한 메소드
		1. Scanner 생성자 호출 후 초기화
		2. 입력 값을 port와 ip에 저장
		3. if문 port가 허용 범위 외인지? 0~65536 
			> InputMismatchException 예외 발생
		4. port, ip를 매개로 클라이언트 소켓 생성
	 	5. 이름을 입력 받고 name 변수에 초기화
		6. 예외 처리
			> 잘못된 port 넘버일 경우; 사용할 수 없거나 사용 중인 port
			> IP가 불가능한 경우
	 */
	private void accessServer() {
		try {
			scanner = new Scanner(System.in);
			System.out.print("[시스템 시작] IP 주소를 입력하세요. \n ☞ ");
			ip = scanner.nextLine();
			
			System.out.print("[시스템 시작] Port 번호를 입력하세요. \n ☞ ");
			port = Integer.parseInt(scanner.nextLine());
			
			client = new Socket(ip, port); 
			
			System.out.print("[서버 접속 중] 사용자 이름을 입력해주세요. \n ☞ ");
			name = scanner.nextLine();
			
		} catch (Exception e) {
			System.out.println("[서버 접속 실패] 잘못된 입력입니다.");
		} 
	}
	
	/*
		registerClient(); 클라이언트 정보 설정
		1. 스트림 변수에 client 소켓 스트림의 값을 초기화함.
		2. name 패킷을 생성함.
		3. 패킷의 바이트 배열을 전송함.
	 */
	private void registerClient() {
		try {
			in = client.getInputStream();
			out = client.getOutputStream();
			
			Packet namePacket = new Packet(name);
			out.write(namePacket.toByteArr());
			out.flush();
			
			System.out.printf("[통신 시작] %s님 환영합니다.%n ☞ ", name);
			
		} catch (Exception e) {
			System.out.println("[통신 실패]");
		}
	}
	
	/*
	 	run(); 스레드 시작
	 	1. sender 스레드 생성
	 		> send() 호출함.
 		2. receiver 스레드 생성
 			> receive() 호출함.
		3. 스레드 시작함.
	 */
	private void run() {
		Thread sender = new Thread() {
			@Override
			public void run() {
				sendMsg();
			}
		};
		
		Thread receiver = new Thread(){
			@Override
			public void run() {
				receiveMsg();
			}
		};

		sender.start();
		receiver.start();
	}
	
	/*
	 	send(); 입력이 있으면 메시지를 전송함.
	 	1. while문 스트림이 초기화되었으면 반복함.
	 		> 입력을 메시지 변수에 초기화함.
	 		> 메시지 패킷을 생성
	 		> 해당 패킷의 바이트 배열을 전송함.
	 */
	public void sendMsg() {
		try {
			while(out != null) {
				String msg = scanner.nextLine();
				Packet msgPacket = new Packet(msg);
				out.write(msgPacket.toByteArr());
				out.flush();
			}
		} catch(Exception e) {
			System.out.println("[메시지 전송 오류]");
		}
	}
	
	/*
	 	receive()
	 	1. while문 스트림이 초기화되었으면 반복함.
	 		> 패킷 생성함.
	 		> 패킷에 스트림 할당함.
	 		> if문 패킷이 업데이트되었는지?
	 			> 패킷의 내용을 출력함.
	 */
	public void receiveMsg() {
		try {
			while(in != null) {
				Packet msgPacket = new Packet(in);
				if(msgPacket.isAvailable()) {
					msgPacket.init();
					System.out.println(msgPacket.toString());
				}
			}
		} catch (Exception e) {
			System.out.println("[메시지 수신 오류]");
		}
	}

	/*
		메인 메소드
		1. 생성자 호출
	 */
	public static void main(String[] args) {
		try {
			new Client();
			
		} catch (Exception e) {
			System.out.println("[시스템 오류] 접속을 강제 종료합니다.");
			System.exit(0);
		}
	}
}