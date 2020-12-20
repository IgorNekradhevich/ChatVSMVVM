using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        ChatM chat;
        ObservableCollection<string> chatHistory;
        public ChatVM()
        {
            chat = new ChatM("127.0.0.1", 8888);
            chatHistory = new ObservableCollection<string>();
        }

      
        public ObservableCollection<string> ChatHistory
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
            
        get {
                return new MyCommand((o) => { chat.SendMessage(message); }); 
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
