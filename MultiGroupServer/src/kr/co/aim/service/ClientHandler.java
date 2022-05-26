package kr.co.aim.service;

import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

import kr.co.aim.manager.GroupManager;
import kr.co.aim.manager.PacketManager;

public class ClientHandler implements Runnable {
	private Socket client;
	private GroupManager groupManager;
	private PacketManager packetManager;
	
	private InputStream in;
	private OutputStream out;
	
	
	public ClientHandler(Socket client) {
		this.client = client;
		this.packetManager = new PacketManager(client);
	}

	@Override
	public void run() {
		try {
			
		} catch (Exception e) {
			// TODO: handle exception
		}
	}
	
	public void addUser() {
		
	}
}
