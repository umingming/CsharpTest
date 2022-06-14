using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BytePacketClient
{
    public class Client
    {
		private TcpClient client;
		private NetworkStream sender;
		private NetworkStream receiver;

		private int index;
		private string name;

		private Notification box = new Notification();
		private ArrayList newMsgList = new ArrayList();
		private ArrayList msgList = new ArrayList();

        /*
			생성자 정의
			1. 매개로 받은 ip, port로 소켓을 생성
			2. 소켓을 이용해 스트림을 초기화함.
			3. 예외처리; 불가능한 Port, IP일 경우
		 */
        public Client(String ip, int port)
        {
			try
            {
				this.client = new TcpClient(ip, port);
				this.sender = client.GetStream();
				this.receiver = client.GetStream();
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
			2. name을 매개로 패킷 생성
			3. 패킷을 바이트 배열에 할당함.
			4. 해당 배열을 스트림으로 전송함.
		 */
        public void SetName(String name)
        {
			try
            {
				this.name = name;
				Packet namePacket = new Packet(name);
				byte[] nameArr = namePacket.ToByteArr();

				sender.Write(nameArr, 0, nameArr.Length);
				sender.Flush();
			}
			catch (IOException)
            {
				box.DisplayError("이름 설정");
            }
        }

		/*
			ReceiveMsg
			1. 메시지 패킷 생성
			2. 스트림 할당.
			3. if문 새로운 패킷이 있는지?
				> 패킷을 문자열로 변환해 리턴함.
				> 없으면 null
		 */
		public string ReceiveMsg()
		{
			Packet msgPacket = new Packet();
			msgPacket.SetStream(receiver);

			if (msgPacket.IsUpdated())
			{
				return msgPacket.ToString();
			}
			return null;
		}

		/*
			SendMsg
			1. 메시지를 인자로 패킷 생성함.
			2. 메시지 배열 선언함.
			3. 배열을 전송함.
		 */
		public void SendMsg(string msg)
        {
			Packet msgPacket = new Packet($"[{name}] {msg}");
            byte[] msgArr = msgPacket.ToByteArr();

            sender.Write(msgArr, 0, msgArr.Length);
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
