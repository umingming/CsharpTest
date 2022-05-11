package kr.co.aim.tcp;

import java.io.DataOutputStream;
import java.net.ConnectException;
import java.net.Socket;

public class MultiClient {
	public static void main(String[] args) {
		if(args.length != 1) {
			System.out.println("USAGE: java MultiClient 대화명");
			System.exit(0);
		}
		
		try {
			String serverIp = "127.0.0.1";
			Socket socket = new Socket(serverIp, 7777);
			System.out.println("서버에 연결되었습니다.");
			Thread sender = new Thread(new ClientSender(socket, arges[0]));
			Thread receiver = new Thread(new ClientReceiver(socket));
			
			sender.start();
			receiver.start();
		} catch(ConnectException ce) {
			ce.printStackTrace();
		} catch(Exception e) {
			e.printStackTrace();
		}
	}
	
	static class ClientSender extends Thread {
		Socket socket;
		DataOutputStream out;
		String name;
		
		ClientSender(Socket socket, String name) {
			this.socket = socket;
			try {
				out = new DataOutputStream(socket.getOutputStream());
				this.name = name;
			} catch(Exception e) {
				e.printStackTrace();
			}
		}
		
	}

}
