using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TCPChat
{
    class ChatVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Changed (string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        string message;
        TcpClient server;
        List<string> chatHistory;

        public ChatVM()
        {
            chatHistory = new List<string>();
            server = new TcpClient("192.168.88.167", 8888);
            Task listner = new Task(serverListner);
            listner.Start();
        }

        void serverListner()
        {
            byte[] buffer = new byte[255];
            while (true)
            {
                NetworkStream stream = server.GetStream();
                stream.Read(buffer, 0, 255);
                string message = Encoding.UTF8.GetString(buffer);
                ChatHistory.Add(message);
                ChatHistory = new List<string>(ChatHistory);
                Console.WriteLine(message);
            }
        }

        public void SendMessageToServer(string message)
        {
            NetworkStream networkStream = server.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            networkStream.Write(buffer, 0, buffer.Length);
        }

        public List<string> ChatHistory
        {
            get
            {
                return chatHistory;
            }

            set
            {
                chatHistory = value;
                Changed("ChatHistory");
            }

        }
        public MyCommand SendMessage
        {
            get
            {
                string message1 = message;
                 Message = "";
                return new MyCommand((o) => { SendMessageToServer(message1); });
            }
        }
      
        public string Message
        {
            get { return message; }
            set { 
                message = value;
                Changed("Message");
                }
        }
    }
}
