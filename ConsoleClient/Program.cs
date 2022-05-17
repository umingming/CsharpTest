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
            byte[] nameArr = Encoding.UTF8.GetBytes(name);
            byte[] header = new byte[4];
            header = BitConverter.GetBytes(nameArr.Length);
            Array.Reverse(header);

            sender.Write(header, 0, header.Length);
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
                byte[] header = new byte[4];

                if(receiver.Read(header, 0, 4) > 0)
                {
                    Array.Reverse(header);
                    var length = BitConverter.ToInt32(header, 0);
                    byte[] msg = new byte[length];
                    sender.Read(msg, 0, length);
                    Console.Write(Encoding.UTF8.GetString(msg));
                }
            }
        }

        private static void Send()
        {
            while (sender != null) {
                byte[] nameArr = Encoding.UTF8.GetBytes(Console.ReadLine());
                byte[] header = BitConverter.GetBytes(nameArr.Length);
                Array.Reverse(header);

                sender.Write(header, 0, header.Length);
                sender.Write(nameArr, 0, nameArr.Length);
                sender.Flush();
            }
        }
    }
}
