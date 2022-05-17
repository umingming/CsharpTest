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

        public Boolean IsUpdated()
        {
            return stream.DataAvailable;
        }

    }
}
