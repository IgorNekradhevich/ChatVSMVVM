   M S B A M L   `   `   `  ����B  >TCPChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TCPChatTCPChat  5   	       TCPChat.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TCPChat     5   	     � Title$  Window1��5   
    � WindowStyle$
 None=�6   $	��220��6.   $	��230��6;    � WindowStartupLocation$ CenterScreen=�6G    � 
ResizeMode$ NoResize=�6l    � DataContext 5	        TCPChat.LoginVM  5
   
   6   .��5      �� .+�5   
   �� $��50,40,50,10q�6   .��6%    Введите ваше имя67   �� 5   
   $��
50,0,50,10q�6M   ��6   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6c   �� 5   
   $��
50,0,50,10q�6   ��6%   �� *
OkButton+.��6B   OK6F   �� 5   
   $��
50,0,50,10q�6   ��6%   �� *CancelButton+.��6F   Отмена6N   5      5      