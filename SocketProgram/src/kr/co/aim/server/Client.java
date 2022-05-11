package kr.co.aim.server;

import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Scanner;

public class Client {
	private static final String IP = "localhost";
	private static final int PORT = 3333;
	private Socket socket;

	public static void main(String[] args) {
		Client client = new Client();
		ConnectThread connect = client.new ConnectThread();
		new Thread(connect).start();
	}

	class ConnectThread implements Runnable {

		@Override
		public void run() {
			try {
				socket = new Socket(IP, PORT);

				ReceiveThread receive = new ReceiveThread();
				SendThread send = new SendThread();
				new Thread(receive).start();
				new Thread(send).start();
			} catch (Exception e) {
				e.printStackTrace();
			} finally {

			}
		}
	}

	class ReceiveThread implements Runnable {

		@Override
		public void run() {
			try {
				
				InputStream in = socket.getInputStream();
				Scanner receiver = new Scanner(new InputStreamReader(in));
				while(true) {
					if(receiver.hasNext()) {
						System.out.printf("%s%n ☞ ", receiver.nextLine());
					}
				}
				
			} catch (Exception e) {
				e.printStackTrace();
			} finally {

			}
		}
	}

	class SendThread implements Runnable {

		@Override
		public void run() {
			try {
				OutputStream out = socket.getOutputStream();
				PrintWriter sender = new PrintWriter(new OutputStreamWriter(out));
				Scanner scanner = new Scanner(System.in);
				String msg;
				while((msg = scanner.nextLine()) != null) {
					if(msg.equals("종료")) {
						break;
					}
					
					sender.println(msg);
					sender.flush();
				}
			} catch (Exception e) {
				e.printStackTrace();
			} finally {

			}
		}
	}
}