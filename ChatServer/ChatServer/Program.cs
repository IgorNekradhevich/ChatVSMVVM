using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {

     public static   void ClientListener (TcpClient client)
        {
            byte[] buffer = new byte[255];
            while (true)
            {
                NetworkStream stream = client.GetStream();
                stream.Read(buffer, 0, 255);
                string message = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(message);
            }
        }
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 8888);
            List<TcpClient> clients = new List<TcpClient>() ;
            listener.Start();
            while (true)
            {
                clients.Add(listener.AcceptTcpClient());
                Console.WriteLine("О чудо у нас гость!");
                Task task = new Task(()=> { ClientListener(clients[clients.Count - 1]); });
                task.Start();
             }
        }
    }
}
