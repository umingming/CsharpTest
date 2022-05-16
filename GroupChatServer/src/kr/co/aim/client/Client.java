package kr.co.aim.client;

import java.io.PrintWriter;
import java.net.Socket;
import java.util.Scanner;

/*
	에코 클라이언트
	- 서버에 메시지를 보내고, 해당 메시지를 돌려 받을 것.
 */
public class Client {
	private Socket client;
	private Scanner in;
	private PrintWriter out;
	
	private String name;
	private String msg;
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
			setClient();
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
			Scanner scanner = new Scanner(System.in);
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
		setClient(); 클라이언트 정보 설정
		1. 스트림 변수에 client 소켓 스트림의 값을 초기화함.
		2. name을 println 메소드로 서버에 전송함.
	 */
	private void setClient() {
		try {
			in = new Scanner(client.getInputStream());
			out = new PrintWriter(client.getOutputStream());
			
			System.out.printf("[통신 시작] %s님 환영합니다.%n ☞ ", name);
			out.println(name);
			out.flush();
			
			Thread sender = new Thread() {
				@Override
				public void run() {
					send();
				}
			};
			
			Thread receiver = new Thread(){
				@Override
				public void run() {
					receive();
				}
			};

			sender.start();
			receiver.start();
			
		} catch (Exception e) {
			System.out.println("[통신 실패]");
		}
	}
	
	public void send() {
		Scanner scanner = new Scanner(System.in);
		try {
			while(out != null) {
				out.println(scanner.nextLine());
				out.flush();
			}
		} catch(Exception e) {
			System.out.println("[메시지 전송 오류]");
		}
	}
	
	public void receive() {
		while(in!=null) {
			try {
				if(in.hasNext()) {
					System.out.println(in.nextLine());
				}
			} catch(Exception e) {
				System.out.println("[메시지 수신 오류]");
			}
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