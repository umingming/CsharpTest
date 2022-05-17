using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ConsoleClient
{
    internal class Packet
    {
        private NetworkStream stream;
        private byte[] header;
        private byte[] body;

        private const int HEADER_LENGTH = 4;

        public Packet()
        {
            header = new byte[HEADER_LENGTH];
        }

        public Packet(string msg)
        {
            body = Encoding.UTF8.GetBytes(msg);
            header = BitConverter.GetBytes(body.Length);
        }
        
        public void SetStream(NetworkStream stream)
        {
            this.stream = stream;
        }

        public Boolean IsUpdated()
        {
            return (stream.Read(header, 0, 4) > 0) ? true : false;
        }

        public string ToString()
        {
            Array.Reverse(header);
            var length = BitConverter.ToInt32(header, 0);
            byte[] msg = new byte[length];
            stream.Read(msg, 0, length);
            return Encoding.UTF8.GetString(msg);
        }

        public byte[] ToByteArr()
        {
            byte[] byteArr = new byte[header.Length + body.Length];
            Array.Reverse(header);
            Array.Copy(header, 0, byteArr, 0, header.Length);
            Array.Copy(body, 0, byteArr, header.Length, body.Length);
            return byteArr;
        }
    }
}
