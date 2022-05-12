package kr.co.aim.nio;

import java.io.IOException;
import java.net.InetSocketAddress;
import java.nio.ByteBuffer;
import java.nio.channels.Channels;
import java.nio.channels.ReadableByteChannel;
import java.nio.channels.SocketChannel;
import java.nio.channels.WritableByteChannel;

public class Client {
	public static void main(String[] args) {
		Thread systemIn;
		try {
			SocketChannel socket = SocketChannel.open(new InetSocketAddress("localhost", 3211));
			WritableByteChannel out = Channels.newChannel(System.out);
			ByteBuffer buf = ByteBuffer.allocate(1024);
			systemIn = new Thread(new SystemIn(socket));
			systemIn.start();
			
			while(true) {
				socket.read(buf);
				buf.flip();
				out.write(buf);
				buf.clear();
			}
			
		} catch (IOException e) {
			System.out.println("서버와 연결이 종료되었습니다.");
		}
	}
}

class SystemIn implements Runnable {
	SocketChannel socket;
	
	SystemIn(SocketChannel socket) {
		this.socket = socket;
	}
	
	@Override
	public void run() {
		ReadableByteChannel in = Channels.newChannel(System.in);
		ByteBuffer buf = ByteBuffer.allocate(1024);
		
		try {
			while(true) {
				in.read(buf);
				buf.flip();
				socket.write(buf);
				buf.clear();
			}
			
		} catch (IOException e) {
			System.out.println("채팅 불가");
		}
	}
}
