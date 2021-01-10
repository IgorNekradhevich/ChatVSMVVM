using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class ClientInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TcpClient Client { get; private set; }
        public ClientInfo(int id, TcpClient client)
        {
            Id = id;
            Name = "user";
            Client = client;
        }

    }
}
