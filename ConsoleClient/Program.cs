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
        private static StreamWriter sender;
        private static StreamReader receiver;

        public static void Main(string[] args)
        {
            AccessServer();
            if(client != null)
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

            Console.Write("[서버 접속 중] 사용자 이름을 입력해주세요. \n ☞ ");
            name = Console.ReadLine();
        }

        private static void setClient()
        {
            sender = new StreamWriter(client.GetStream());
            receiver = new StreamReader(client.GetStream());

            sender.WriteLine(name);
            sender.Flush();

            Thread senderThread = new Thread(() => send());
            Thread receiverThread = new Thread(() => receive());
            senderThread.Start();
            receiverThread.Start();
        }

        private static void receive()
        {
            var msg = "";
            while ((msg = receiver.ReadLine()) != null) {
                Console.WriteLine(msg);
            }
        }

        private static void send()
        {
            while (sender != null) {
                var msg = string.Format("[{0}]{1}", name, Console.ReadLine());
                sender.WriteLine(msg);
                sender.Flush();
            }
        }
    }
}
