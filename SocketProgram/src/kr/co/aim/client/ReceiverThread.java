package kr.co.aim.client;

import java.io.DataInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.Socket;
import java.util.Scanner;

public class ReceiverThread implements Runnable {
	private Socket socket;
	private DataInputStream in;
	
	public ReceiverThread(Socket socket) {
		this.socket = socket;
		
		try {
			in = new DataInputStream(socket.getInputStream());
			
		} catch(Exception e) {
			System.out.println("[클라이언트 소켓 오류]");
		}
	}
	

	@Override
	public void run() {
		while(in!=null) {
			try {
				System.out.println(in.readUTF());
			} catch(Exception e) {
				System.out.println("[메시지 수신 오류]");
			}
		}
	}
}
