package kr.co.aim.client;

import java.io.DataOutputStream;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Scanner;

public class SenderThread implements Runnable {
	private Socket socket;
	private PrintWriter out;
	private String name;
	private Scanner scanner;
	
	public SenderThread(Socket socket, String name) {
		this.socket = socket;
		this.name = name;
		
		try {
			out = new PrintWriter(socket.getOutputStream());
			
			if(out != null) {
				out.write(name);
				System.out.println("[이름 전송]");
			}
		} catch (Exception e) {
			System.out.println("[클라이언트 소켓 오류]");
		}
	}

	@Override
	public void run() {
		scanner = new Scanner(System.in);
		try {
			while(out != null) {
				String msg = String.format("[%s]%s", name, scanner.nextLine());
				out.write(msg);
			}
		} catch(Exception e) {
			System.out.println("[메시지 전송 오류]");
		}
	}
}
