package kr.co.aim.tcp;

import java.net.ServerSocket;
import java.net.Socket;
import java.util.Collections;
import java.util.HashMap;

public class MultiServer {
	HashMap clients;
	
	MultiServer() {
		clients = new HashMap();
		Collections.synchronizedMap(clients);
	}
	
	public void start() {
		ServerSocket serverSocket = null;
		Socket socket = null;
		
		try {
			serverSocket = new ServerSocket(7777);
			System.out.println("서버 시작");
			
			while(true) {
				socket = serverSocket.accept();
				System.out.println("[" + socket.getInetAddress() + ":" + socket.getPort() + "] 에서 접속했습니다.");
				ServerReceiver thread = new ServerReceiver(socket);
				thread.start();
			}
		} catch(Exception e) {
			e.printStackTrace();
		}
	}
	
	
	

}
