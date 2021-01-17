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
        static List<ClientInfo> clients;

        public static void ClientListener(ClientInfo client)
        {
            byte[] buffer = new byte[255];
            bool isConnected = true;
            while (isConnected)
            {
                buffer = new byte[255];
                try
                {
                    NetworkStream stream = client.Client.GetStream();
                    stream.Read(buffer, 0, 255);
                    string message = Encoding.UTF8.GetString(buffer);
                    if (message.IndexOf("\0") > 0)
                        message = message.Remove(message.IndexOf("\0"));

                    if (message.IndexOf("<name>") == 0)
                    {
                        int index = clients.IndexOf(client);
                        clients[index].Name = message.Remove(0, 6);
                        client.Name = message.Remove(0, 6);
                        client.Name += "\0";
                        RefreshOnlineList();
                    }
                    else
                    { 
                        message = client.Name + ":" + message;
                        Console.WriteLine(message);
                        buffer = new byte[255];
                        buffer= Encoding.UTF8.GetBytes(message);
                        foreach (ClientInfo tcpClient in clients)
                        {
                            NetworkStream writer = tcpClient.Client.GetStream();
                            writer.Write(buffer, 0, buffer.Length);
                        }

                    }
                } catch
                {
                    isConnected = false;
                    Console.WriteLine(client.Name +" Ушел");
                    clients.Remove(client);
                    RefreshOnlineList();
                }
            }
        }

       static void RefreshOnlineList()
        {
            string message = "<Online>";
            foreach(ClientInfo name in clients)
            {
                message += name.Name + "|";
            }
            // <Online> Игорь|Маша|Даша|
            byte[] buffer = new byte[255];
            buffer = Encoding.UTF8.GetBytes(message);
            foreach (ClientInfo tcpClient in clients)
            {
                NetworkStream writer = tcpClient.Client.GetStream();
                writer.Write(buffer, 0, buffer.Length);
            }
        }
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 8888);
            clients = new List<ClientInfo>() ;
            listener.Start();
            int count = 0;
            while (true)
            {
                count++;

                clients.Add( new ClientInfo(count, listener.AcceptTcpClient()));
                Console.WriteLine("О чудо у нас гость!");
                Task task = new Task(()=> { ClientListener(clients[clients.Count - 1]); });
                task.Start();
           
            }
        }
    }
}
