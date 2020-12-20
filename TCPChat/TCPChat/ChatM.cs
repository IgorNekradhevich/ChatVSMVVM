using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPChat
{
    class ChatM
    {
        TcpClient user;
        public ChatM(string ip, int port)
        {
            user = new TcpClient();
            user.Connect(ip,port);
        }

        public void SendMessage(string message)
        {
            NetworkStream networkStream = user.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            networkStream.Write(buffer, 0, buffer.Length);
        }
    }
}
