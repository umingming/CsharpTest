package kr.co.aim.server;

import java.nio.ByteBuffer;

public class Packet {
	private byte[] header;
	private byte[] body;
	
	public Packet() {
		this.header = new byte[4];
		this.body = new byte[1024];
	}
	
	public Packet(String msg) {
		this.body = msg.getBytes();
		this.header = ByteBuffer.allocate(4).putInt(body.length).array();
	}

	public byte[] getHeader() {
		return header;
	}

	public byte[] getBody() {
		return body;
	}
	
	public byte[] toByteArr() {
		
	}
}
