package kr.co.aim.nio;

import java.net.InetSocketAddress;
import java.nio.ByteBuffer;
import java.nio.channels.SelectionKey;
import java.nio.channels.Selector;
import java.nio.channels.ServerSocketChannel;
import java.nio.channels.SocketChannel;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Set;

public class Server {
	public static void main(String[] args) {
		Set<SocketChannel> clientSet = new HashSet<>();
		
		try (ServerSocketChannel server = ServerSocketChannel.open()) {
			server.bind(new InetSocketAddress(15000));
			server.configureBlocking(false);
			
			Selector selector = Selector.open();
			server.register(selector, SelectionKey.OP_ACCEPT);
			
			System.out.printf("[서버 생성 성공] Port 번호는 %d입니다.%n"
								, server.socket().getLocalPort());
			
			ByteBuffer inputBuf = ByteBuffer.allocate(1024);
			ByteBuffer outputBuf = ByteBuffer.allocate(1024);
			
			while (true) {
				selector.select();
				Iterator<SelectionKey> iterator = selector.selectedKeys().iterator();
				
				while (iterator.hasNext()) {
					SelectionKey key = iterator.next();
					iterator.remove();
					
					if (key.isAcceptable()) {
						ServerSocketChannel channel = (ServerSocketChannel) key.channel();
						SocketChannel client = channel.accept();
						
						client.configureBlocking(false);
						clientSet.add(client);
						
						client.write(ByteBuffer.wrap("아이디를 입력해주세요 : ".getBytes()));
						
						client.register(selector, SelectionKey.OP_READ, new ClientInfo());
						
					} else if (key.isReadable()) {
						SocketChannel readSocket = (SocketChannel) key.channel();
						ClientInfo info = (ClientInfo) key.attachment();
						
						try {
							readSocket.read(inputBuf);
						} catch (Exception e) {
							key.cancel();
							clientSet.remove(readSocket);
							String end = info.getId() + "님의 연결이 종료되었습니다.\n";
							System.out.println(end);
							outputBuf.put(end.getBytes());
							for(SocketChannel channel : clientSet) {
								if(!readSocket.equals(channel)) {
									outputBuf.flip();
									channel.write(outputBuf);
								}
							}
							outputBuf.clear();
							continue;
						}
						
						if(info.getId() == null) {
							inputBuf.limit(inputBuf.position() - 2);
							inputBuf.position(0);
							byte[] id = new byte[inputBuf.limit()];
							inputBuf.get(id);
							info.setId(new String(id));
							
							String enter = info.getId() + "님이 입장하셨습니다. \n";
							System.out.print(enter);
							
							outputBuf.put(enter.getBytes());
							
							for(SocketChannel client : clientSet) {
								outputBuf.flip();
								client.write(outputBuf);
							}
							
							inputBuf.clear();
							outputBuf.clear();
							continue;
						}
						
						inputBuf.flip();
						outputBuf.put((info.getId() + ":").getBytes());
						outputBuf.put(inputBuf);
						outputBuf.flip();
						
						for(SocketChannel client : clientSet) {
							if(!readSocket.equals(client)) {
								client.write(outputBuf);
								outputBuf.flip();
							}
						}
						
						inputBuf.clear();
						outputBuf.clear();
					}
				}
			}
			
		} catch (Exception e) {
			// TODO: handle exception
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

