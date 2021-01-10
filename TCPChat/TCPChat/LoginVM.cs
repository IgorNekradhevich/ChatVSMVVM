using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TCPChat
{
    class LoginVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Changed(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                Changed("Name");
            }

        }

        public MyCommand CancelButton
        {
            get
            {
                return new MyCommand((o) => Application.Current.Shutdown());
            }
        }
        public MyCommand OkButton
        {
            get
            {
                return new MyCommand((o) =>
                {
                    if(name!="" && name!=null)
                    {
                        //MessageBox.Show(name);
                        ChatVM.name = name;
                        ChatVM.reg.Close();
                    }
                    else 
                    {
                        MessageBox.Show("Укажите имя");
                    }
                });
            }
        }
    }
}
