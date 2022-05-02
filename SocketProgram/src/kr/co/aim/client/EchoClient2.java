package kr.co.aim.client;

import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.SocketException;
import java.net.UnknownHostException;
import java.util.InputMismatchException;
import java.util.Scanner;

/*
	에코 클라이언트
	- 서버에 메시지를 보내고, 해당 메시지를 돌려 받을 것.
 */
public class EchoClient2 {
	private static Socket client;
	
	private static String name;
	private static String msg;
	private static String ip;
	private static int port;
	
	private static OutputStream out;
	private static InputStream in;
	private static PrintWriter sender;
	private static Scanner receiver;
	private static Scanner scanner;
	
	/*
		생성자 정의
		1. accessServer 메소드 호출
		2. if문 클라이언트가 null이 아닌지? 
			> setClient 메소드
			> communicate 메소드 호출
			> close 메소드 호출
	 */

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
	private static void accessServer() {
		try {
			scanner = new Scanner(System.in);
			System.out.print("[시스템 시작] IP 주소를 입력하세요. \n ☞ ");
			ip = scanner.nextLine();
			
			System.out.print("[시스템 시작] Port 번호를 입력하세요. \n ☞ ");
			port = Integer.parseInt(scanner.nextLine());
			
			if(port < 0 || port > 65535) {
				throw new InputMismatchException();
			}
			
			client = new Socket(ip, port); 
			System.out.print("[서버 접속 중] 사용자 이름을 입력해주세요. \n ☞ ");
			name = scanner.nextLine();
			
		} catch (InputMismatchException e) {
			System.out.println("[서버 접속 실패] Port 번호는 0 또는 65536 이하의 양수입니다.");
		} catch (SocketException e) {
			System.out.printf("[서버 접속 실패] %d는 불가능한 Port입니다.", port);
		} catch (UnknownHostException e) {
			System.out.printf("[서버 접속 실패] %s는 불가능한 IP입니다.", ip);
		} catch (IOException e) {
			System.out.println("[서버 접속 실패] 잘못된 입력입니다.");
		} 
	}
	
	/*
		setClient(); 클라이언트 정보 설정
		1. 스트림 변수에 client 소켓 스트림의 값을 초기화함.
		2. name을 println 메소드로 서버에 전송함.
	 */
	private static void setClient() {
		try {
			out = client.getOutputStream();
			sender = new PrintWriter(new OutputStreamWriter(out));
	
			in = client.getInputStream();
			receiver = new Scanner(new InputStreamReader(in));
			
			sender.println(name);
			System.out.printf("[통신 시작] %s님 환영합니다.%n ☞ ", name);
			
		} catch (IOException e) {
			System.out.println("[통신 실패]");
		}
	}

	/*
		communicate 메소드
		1. while문 입력 값을 msg에 초기화 후 null이 아닐 경우 반복함.  
			> if문 msg가 종료이면, break
			> msg를 println으로 서버에 전송하고 flush 메소드로 확인함.
			> 서버로부터 돌려 받은 값을 출력함.
	 */
	private static void communicate() {
		while((msg = scanner.nextLine()) != null) {
			if(msg.equals("종료")) {
				break;
			}
			
			sender.println(msg);
			sender.flush();
			System.out.printf("%s%n ☞ ", receiver.nextLine());
		}
	}
	
	/*
		close 메소드
		1. 스트림과 소켓을 역순으로 닫음.
		2. 접속 종료 여부를 안내함.
	 */
	private static void close() {
		try {
			sender.close();
			out.close();
			receiver.close();
			in.close();
			client.close();
			System.out.println("[서버 접속 종료]");
			
		} catch (IOException e) {
			System.out.println("[접속 종료 실패]");
		}
	}
	
	/*
		메인 메소드
		1. 생성자 호출
	 */
	public static void main(String[] args) {
		try {
			System.gc(); 
			long before = Runtime.getRuntime().totalMemory() - Runtime.getRuntime().freeMemory();
			
			accessServer();
			
			if(client != null) {
				setClient();
				communicate();
				close();
			}
			
			System.gc();
			long after  = Runtime.getRuntime().totalMemory() - Runtime.getRuntime().freeMemory();
			long usedMemory = (before - after);
			System.out.println("Used Memory : " + usedMemory);
			
		} catch (Exception e) {
			System.out.println("[시스템 오류] 접속을 강제 종료합니다.");
			System.exit(0);
		}
	}
}