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

        
    
    }
}
