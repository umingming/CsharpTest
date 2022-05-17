using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleClient
{
    internal class Program
    {
        private static TcpClient client;
        private static string name;
        private static NetworkStream sender;
        private static NetworkStream receiver;

        public static void Main(string[] args)
        {
            AccessServer();
            if(name != null)
            {
                setClient();
            }
        }

        private static void AccessServer()
        {
            Console.Write("[시스템 시작] IP 주소를 입력하세요. \n ☞ ");
            var ip = Console.ReadLine();

            Console.Write("[시스템 시작] Port 번호를 입력하세요. \n ☞ ");
            var port = Convert.ToInt32(Console.ReadLine());

            client = new TcpClient();
            client.Connect(ip, port);

            sender = client.GetStream();
            receiver = client.GetStream();

            Console.Write("[서버 접속 중] 사용자 이름을 입력해주세요. \n ☞ ");
            name = Console.ReadLine();
        }

        private static void setClient()
        {
            Packet namePacket = new Packet(name);
            byte[] nameArr = namePacket.ToByteArr();

            sender.Write(nameArr, 0, nameArr.Length);
            sender.Flush();

            Thread senderThread = new Thread(() => Send());
            Thread receiverThread = new Thread(() => Receive());
            senderThread.Start();
            receiverThread.Start();
        }

        private static void Receive()
        {
            while (receiver != null) {
                Packet msgPacket = new Packet();
                msgPacket.SetStream(receiver);

                if(msgPacket.IsUpdated())
                {
                    Console.Write(msgPacket.ToString());
                }
            }
        }

        private static void Send()
        {
            while (sender != null) {
                var msg = Console.ReadLine();
                Packet msgPacket = new Packet(msg);
                byte[] msgArr = msgPacket.ToByteArr();

                sender.Write(msgArr, 0, msgArr.Length);
                sender.Flush();
            }
        }
    }
}
