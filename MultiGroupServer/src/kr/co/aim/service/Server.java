package kr.co.aim.service;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Scanner;

public class Server {
	private ServerSocket server;
	private Socket client;
	
	private boolean keepProcessing = true;
	private int port;
	
	/*
		registerServer(); 서버 생성
		1. 입력 값을 port에 저장
		2. port를 매개로 서버소켓 생성 후 안내 메시지 출력
		3. 그룹 두 개 생성함.
		4. 예외처리
			> port 넘버를 잘못 입력했을 경우
			> 이미 존재하는 port의 경우
	 */
	private void registerServer() {
		try {
			server = new ServerSocket(port);
			System.out.printf("[서버 생성 성공] Port 번호는 %d입니다.%n"
								, server.getLocalPort());
		} catch (Exception e) {
			System.out.println("[서버 생성 실패] 잘못된 입력입니다.");
		} 
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
			while(keepProcessing) {
				client = server.accept();
				System.out.println("[사용자 접속 대기]");
				
				ClientHandler clientHandler = new ClientHandler(client);
				Thread thread = new Thread(clientHandler);
				thread.start();
			}
		} catch (IOException e) {
			System.out.println("[사용자 접속 실패]");
		}
	}

	/*
		메인 메소드
		1. 생성자 호출
	 */
	public static void main(String[] args) {
		try {
			new Server();
			
		} catch(Exception e) {
			System.out.println("[시스템 오류] 접속을 강제 종료합니다.");
			e.printStackTrace();
			System.exit(0);
		}
	}
}
