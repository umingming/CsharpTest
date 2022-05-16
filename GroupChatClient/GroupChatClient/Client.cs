using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GroupChatClient
{
    public class Client
    {
		private TcpClient client;
		private StreamWriter sender;
		private StreamReader receiver;

		private int index;
		private string name;

		private Notification box = new Notification();
		private ArrayList newMsgList = new ArrayList();
		private ArrayList msgList = new ArrayList();

        /*
			생성자 정의
			1. 매개로 받은 ip, port로 소켓을 생성
			2. 소켓의 스트림을 인자로, 스트림 생성자를 호출해 I/O스트림 초기화함.
			3. 예외처리; 불가능한 Port, IP일 경우
		 */
        public Client(String ip, int port)
        {
			try
            {
				this.client = new TcpClient(ip, port);
				this.sender = new StreamWriter(client.GetStream());
				this.receiver = new StreamReader(client.GetStream());
			}
			catch (SocketException)
			{
				box.DisplayWarning("접속 정보");
			}
			catch (Exception)
			{
				box.DisplayError();
			}
		}

        /*
			SetName
			1. 인자 값을 name 필드 변수에 할당함.
			2. name 변수를 서버에 전송 
		 */
        public void SetName(String name)
        {
			try
            {
				this.name = name;
				sender.WriteLine(this.name);
				sender.Flush();
			}
			catch (IOException)
            {
				box.DisplayError("이름 설정");
            }
        }

		/*
			ReceiveMsg
			1. 서버로부터 받은 메시지를 반환
		 */
		public string ReceiveMsg()
		{
			return receiver.ReadLine();
		}

		/*
			SendMsg
			1. 인자로 받은 메시지를 서버에 전송
			2. Flush 호출해서 stream 확인
		 */
		public void SendMsg(string msg)
        {
			sender.WriteLine(msg);
			sender.Flush();
		}

		/*
			Close
			1. 스트림과 소켓을 역순으로 닫음.
		 */
		public void Close()
        {
			try
            {
				receiver.Close();
				sender.Close();
				client.Close();
            }
			catch (IOException)
            {
				box.DisplayError("접속 종료");
			}
        }
	}
}
