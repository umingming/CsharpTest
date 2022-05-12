package kr.co.aim.nio;

import java.io.IOException;
import java.net.InetSocketAddress;
import java.net.SocketException;
import java.nio.ByteBuffer;
import java.nio.channels.SelectionKey;
import java.nio.channels.Selector;
import java.nio.channels.ServerSocketChannel;
import java.nio.channels.SocketChannel;
import java.util.HashSet;
import java.util.InputMismatchException;
import java.util.Iterator;
import java.util.Scanner;
import java.util.Set;

public class Server {
	private ServerSocketChannel server;
	private Selector selector;
	private SelectionKey key;
	private ByteBuffer input = ByteBuffer.allocate(1024);
	private ByteBuffer output = ByteBuffer.allocate(1024);
	
	private Iterator<SelectionKey> iterator;
	private Set<SocketChannel> clientSet = new HashSet<>();
	
	public static void main(String[] args) {
		new Server();
	}
	
	public Server() {
		while(server == null) {
			setServer();
		}
		run();
	}

	private void run() {
		while(true) {
			if (iterator.hasNext()) {
				key = iterator.next();
				iterator.remove();
				checkEvent();
			}
		}
	}
	
	private void checkEvent() {
		try {
			if (key.isAcceptable()) {
				setClient();					
			} else if (key.isReadable()) {
				SocketChannel readSocket = (SocketChannel) key.channel();
				ClientInfo info = (ClientInfo) key.attachment();
				
				try {
					readSocket.read(input);
				} catch (Exception e) {
					key.cancel();
					clientSet.remove(readSocket);
					String end = info.getId() + "님의 연결이 종료되었습니다.\n";
					System.out.println(end);
					output.put(end.getBytes());
					for(SocketChannel channel : clientSet) {
						if(!readSocket.equals(channel)) {
							output.flip();
							channel.write(output);
						}
					}
					output.clear();
				}
				
				if(info.getId() == null) {
					input.limit(input.position() - 2);
					input.position(0);
					byte[] id = new byte[input.limit()];
					input.get(id);
					info.setId(new String(id));
					
					String enter = info.getId() + "님이 입장하셨습니다. \n";
					System.out.print(enter);
					
					output.put(enter.getBytes());
					
					for(SocketChannel client : clientSet) {
						output.flip();
						client.write(output);
					}
					
					input.clear();
					output.clear();
				}
				
				input.flip();
				output.put((info.getId() + ":").getBytes());
				output.put(input);
				output.flip();
				
				for(SocketChannel client : clientSet) {
					if(!readSocket.equals(client)) {
						client.write(output);
						output.flip();
					}
				}
				
				input.clear();
				output.clear();
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		
	}

	private void setClient() throws IOException {
		ServerSocketChannel channel = (ServerSocketChannel) key.channel();
		SocketChannel client = channel.accept();
		
		client.configureBlocking(false);
		clientSet.add(client);
		
		client.write(ByteBuffer.wrap("아이디를 입력해주세요 : ".getBytes()));
		
		client.register(selector, SelectionKey.OP_READ, new ClientInfo());
	}

	private void setServer() {
		try {
			Scanner scanner = new Scanner(System.in);
			
			System.out.print("[시스템 시작] Port 번호를 입력하세요. \n ☞ ");
			int port = scanner.nextInt();
			
			server = ServerSocketChannel.open();
			server.bind(new InetSocketAddress(port));
			server.configureBlocking(false);
			
			
			System.out.printf("[서버 생성 성공] Port 번호는 %d입니다.%n"
					, server.socket().getLocalPort());
			
			selector = Selector.open();
			server.register(selector, SelectionKey.OP_ACCEPT);
			selector.select();
			iterator = selector.selectedKeys().iterator();
			
		} catch (InputMismatchException e) {
			System.out.println("[서버 생성 실패] 65536 보다 작은 양수를 입력하세요.");
		} catch (SocketException e) {
			System.out.println("[서버 생성 실패] 불가능한 Port입니다.");
		} catch (IOException e) {
			System.out.println("[서버 생성 실패] 잘못된 입력입니다.");
		} 
	}
}
	
class ClientInfo {
	private String id;
	
	public String getId() {
		return id;
	}
	
	public void setId(String id) {
		this.id = id;
	}
}

