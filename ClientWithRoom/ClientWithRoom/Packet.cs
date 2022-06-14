using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ClientWithRoom
{
    /*
        Packet; 데이터를 헤더와 바디로 구분
     */
    public class Packet
    {
        private NetworkStream stream;
        private byte[] header;
        private byte[] type;
        private byte[] option;
        private byte[] body;

        private const int HEADER_LENGTH = 4;
        private const int TYPE_LENGTH = 2;
        private const int OPTION_LENGTH = 2;

        public Packet()
        {
            header = new byte[HEADER_LENGTH];
            type = new byte[TYPE_LENGTH];
            option = new byte[OPTION_LENGTH];
        }

        /*
            생성자 정의
            1. 인자로 받은 메시지를 형변환해, body에 초기화함.
            2. body의 길이 byte 배열로 변환해 header에 할당함.
         */
        public Packet(string msg)
        {
            type = new byte[TYPE_LENGTH];
            option = new byte[OPTION_LENGTH];
            body = Encoding.UTF8.GetBytes(msg);
            header = BitConverter.GetBytes(body.Length);
        }

        public void SetStream(NetworkStream stream)
        {
            this.stream = stream;
        }
        
        public void SetType(string type)
        {
            this.type = Encoding.UTF8.GetBytes(type);
        }
        
        public void SetOption(string option)
        {
            this.option = Encoding.UTF8.GetBytes(option);
        }

        /*
            IsUpdated; 받은 메시지가 있는지
            1. 스트림을 읽어 헤더에 저장하고, 이 값이 0보다 큰지?
                > 크면 읽은 데이터가 있는 것으로 true 리턴
         */
        public Boolean IsUpdated()
        {
            return (stream.Read(header, 0, 4) > 0) ? true : false;
        }

        /*
            ToString; 패킷을 문자열로 반환함.
            1. 자바와 c# 배열은 역순이라 reverse 메소드 사용해 정상화
            2. header의 값을 읽어 length 변수에 초기화
            3. length를 길이로 하는 byte 배열 선언함.
            4. 스트림을 읽어 msg에 할당
            5. 메시지를 문자열로 변환해 반환
         */
        public string ToString()
        {
            Array.Reverse(header);
            var length = BitConverter.ToInt32(header, 0);
            byte[] msg = new byte[length];
            stream.Read(msg, 0, length);
            return Encoding.UTF8.GetString(msg);
        }

        /*
            ToByteArr; 바이트 배열로 변환
            1. Reverse 메소드로 header를 바르게 함.
            2. 헤더와 바디의 길이만큼 byte 배열을 선언함.
            3. 헤더와 바디를 배열에 카피
            4. 해당 배열 반환
         */
        public byte[] ToByteArr()
        {
            Array.Reverse(header);
            byte[] byteArr = new byte[header.Length + type.Length + option.Length + body.Length];
            Array.Copy(header, 0, byteArr, 0, header.Length);
            Array.Copy(type, 0, byteArr, header.Length, type.Length);
            Array.Copy(option, 0, byteArr, type.Length, option.Length);
            Array.Copy(body, 0, byteArr, option.Length, body.Length);
            return byteArr;
        }
    }
}
