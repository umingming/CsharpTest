package kr.co.aim.client;

import java.io.DataOutputStream;
import java.net.Socket;
import java.util.Scanner;

public class SenderThread implements Runnable {
	private Socket socket;
	private DataOutputStream out;
	private String name;
	
	public SenderThread(Socket socket, String name) {
		this.socket = socket;
		this.name = name;
		
		try {
			out = new DataOutputStream(socket.getOutputStream());
		} catch (Exception e) {
			System.out.println("[클라이언트 소켓 오류]");
		}
	}

	@Override
	public void run() {
		Scanner scanner = new Scanner(System.in);
		try {
			if(out != null) {
				out.writeUTF(name);
			}
			while(out != null) {
				String msg = String.format("[%s]%s", name, scanner.nextLine());
				out.writeUTF(msg);
			}
		} catch(Exception e) {
			System.out.println("[메시지 전송 오류]");
		}
	}
}
