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
import java.util.Calendar;
import java.util.HashMap;
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
	
	private int port;
	private int index;
	
	/*
		생성자 정의
		1. setServer 메소드 호출
		2. if문 server가 null이 아닌지?
			> run() 메소드 호출
	 */		
	public EchoServer() {
		setServer();
		
		if(server != null) {
			start();
		}
	}
	
	/*
		setServer(); 서버 생성
		1. 입력 값을 port에 저장
		2. if문 port가 허용 범위 외인지? (0~65535)
			> InputMismatchException 예외 처리
		3. port를 매개로 서버소켓 생성 후 안내 메시지 출력
		4. 예외처리
			> port 넘버를 잘못 입력했을 경우
			> 이미 존재하는 port의 경우
	 */
	private void setServer() {
		try {
			Scanner scanner = new Scanner(System.in);
			
			System.out.print("[시스템 시작] Port 번호를 입력하세요. \n ☞ ");
			port = scanner.nextInt();
			
			server = new ServerSocket(port);
			System.out.printf("[서버 생성 성공] Port 번호는 %d입니다.%n"
								, server.getLocalPort());
			
		} catch (Exception e) {
			System.out.println("[서버 생성 실패] 잘못된 입력입니다.");
		} 
	}
	
	/*
		run(); 클라이언트의 접속을 확인하고 스레드 생성
		1. while문 무한 루프
			> 클라이언트 접근 확인 후 client 소켓에 초기화
			> 해당 클라이언트를 매개로 ServerThread 객체 생성
			> 스레드를 생성해 start 메소드 호출
	 */
	private void start() {
		try {
			createGroup(2);
			
			while(true) {
				client = server.accept();
				System.out.println("[사용자 접속 대기]");
				
				if(groupList.get(index).isFull()) {
					createGroup(2);
					index++;
				}
				
				Thread thread = new Thread() {
					public void run() {
						connect(client, groupList.get(index));
					}
				};
				thread.start();
			}
			
		} catch (IOException e) {
			System.out.println("[사용자 접속 실패]");
		}
	}
	
	private void createGroup(int total) {
		ClientGroup group = new ClientGroup(2);
		groupList.add(group);
	}

	private void connect(Socket client, ClientGroup group) {
		try {
			DataInputStream in = new DataInputStream(client.getInputStream());
			DataOutputStream out = new DataOutputStream(client.getOutputStream());
			
			String name = in.readUTF();
			group.getClientMap().put(name, out);
			
			System.out.printf("[사용자 접속 성공] %s님이 접속했습니다.%n", name);
			
			while(in != null) {
				String msg = in.readUTF();
				send(msg, group);
				System.out.println(msg);
			}
			
			in.close();
			out.close();
			client.close();
			
		} catch (Exception e) {
			// TODO: handle exception
		}
		
	}
	
	private void send(String msg, ClientGroup group) {
		Iterator it = group.getClientMap().keySet().iterator();
				
		while(it.hasNext()) {
			try {
				DataOutputStream out = (DataOutputStream)group.getClientMap().get(it.next());
				out.writeUTF(msg);
			} catch (IOException e) {
				e.printStackTrace();
			}
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