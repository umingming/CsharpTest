package kr.co.aim.server;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.Scanner;

/*
	에코 서버
	- 서버를 생성하고 클라이언트의 접근을 확인해 스레드 생성
 */
public class EchoServer {
	private ServerSocket server;
	private Socket client;
	private ArrayList<ClientGroup> groupList = new ArrayList<>();
	
	private int index;
	
	/*
		생성자 정의
		1. setServer 메소드 호출
		2. if문 server가 null이 아닌지?
			> run() 메소드 호출
	 */		
	public EchoServer() {
		while(server == null) {
			setServer();
		}
		start();
	}
	
	/*
		setServer(); 서버 생성
		1. 입력 값을 port에 저장
		2. port를 매개로 서버소켓 생성 후 안내 메시지 출력
		3. 그룹 두 개 생성함.
		4. 예외처리
			> port 넘버를 잘못 입력했을 경우
			> 이미 존재하는 port의 경우
	 */
	private void setServer() {
		try {
			Scanner scanner = new Scanner(System.in);
			
			System.out.print("[서버 생성] Port 번호를 입력하세요. \n ☞ ");
			int port = scanner.nextInt();
			
			server = new ServerSocket(port);
			System.out.printf("[서버 생성 성공] Port 번호는 %d입니다.%n"
								, server.getLocalPort());
			
			createGroup(2);
			createGroup(2);
			
		} catch (Exception e) {
			System.out.println("[서버 생성 실패] 잘못된 입력입니다.");
		} 
	}
	
	/*
	 	createGroup; 그룹 생성
	 	1. 매개변수를 크기로 하는 그룹 객체 생성함.
	 	2. 해당 그룹을 리스트에 저장
	 */
	private void createGroup(int total) {
		ClientGroup group = new ClientGroup(total);
		groupList.add(group);
	}
	
	/*
		start(); 클라이언트의 접속을 확인하고 스레드 생성
		1. while문 그룹이 2개 이하일 경우 반복
			> 클라이언트 접근 확인 후 client 소켓에 초기화
			> 스레드 선언 후 run 메소드 오버라이딩
				> 클라이언트와, 그룹을 연결하기 위한 메소드 호출
			> 스레드를 시작함.
			> if 해당 그룹이 만원인지?
				> index++
	 */
	private void start() {
		try {
			while(groupList.size() < 3) {
				client = server.accept();
				System.out.println("[사용자 접속 대기]");
				
				Thread thread = new Thread() {
					@Override
					public void run() {
						connect(client, groupList.get(index));
					}
				};
				thread.start();
				
				if(groupList.get(index).isFull()) {
					index++;
				}
			}
			
		} catch (IOException e) {
			System.out.println("[사용자 접속 실패]");
		}
	}

	/*
	 	connect; 클라이언트가 그룹에 연결되어, 메시지를 보냄.
	 	1. 스트림 변수에 client 소켓 스트림 값을 초기화함.
	 	2. input 값을 이름에 할당함.
	 	3. 클라이언트의 이름과, Output 스트림을 그룹에 저장함.
	 	4. 사용자 접속 안내
	 	5. while문 input이 있을 경우를 조건으로 반복함.
	 		> input 값을 그룹에게 보내기 위해 send 메소드 호출함.
	 */
	private void connect(Socket client, ClientGroup group) {
		try {
			DataInputStream in = new DataInputStream(client.getInputStream());
			DataOutputStream out = new DataOutputStream(client.getOutputStream());
			
			String name = in.readUTF();
			group.getClientMap().put(name, out);
			
			System.out.printf("[사용자 접속 성공] %s님이 접속했습니다.%n", name);
			
			while(in != null) {
				send(in.readUTF(), group);
			}
			
		} catch (Exception e) {
			System.out.println("[사용자 접속 실패]");
		}
	}
	
	/*
		send; 메시지를 그룹에게 전송함.
		1. group을 클라이언트 이름으로 탐색하고자, Iterator 사용
		2. 탐색이 가능한지를 조건으로 while문 반복
		  > 해당 반복자의 이름을 key로 스트림을 얻어 변수에 초기화함.
		  > 메시지를 해당 스트림으로 전송함.
	 */
	private void send(String msg, ClientGroup group) {
		try {
			System.out.println(msg);
			Iterator<String> iterator = group.getClientMap().keySet().iterator();
			
			while(iterator.hasNext()) {
				DataOutputStream out = group.getClientMap().get(iterator.next());
				out.writeUTF(msg);
			}
			
		} catch (Exception e) {
			System.out.println("[메시지 송신 오류]");
		}
	}
	
	/*
		메인 메소드
		1. 생성자 호출
	 */
	public static void main(String[] args) {
		try {
			new EchoServer();
			
		} catch(Exception e) {
			System.out.println("[시스템 오류] 접속을 강제 종료합니다.");
			e.printStackTrace();
			System.exit(0);
		}
	}
}