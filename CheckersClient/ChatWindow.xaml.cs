using AddService.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CheckersClient
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public string User { get; set; }
        public string Header { get; set; }
        BL.Logic LogicInstance = BL.Logic.Instance;

        public ObservableCollection<string> ChatUsers { get; set; }
        private ChattingService.ChatServiceClient _chatClient;

        public ChatWindow(string _user)
        {
            InitializeComponent();
            DataContext = this;
            User = _user;
            Header = "Hello " + User;
            ChatUsers = LogicInstance.ChatCollection;
        }

        private delegate void HandleBroadcastCallback(object sender, EventArgs e);
        public void HandleBroadcastForChat(object sender, EventArgs e)
        {
            string message;
            try
            {
                var chatEvent = (ChatEvents)sender;
                message = this.txtMsg.Text;
                this.txtMessages.Text += chatEvent.UserName + ": " + chatEvent.Message + "\r\n";
            }
            catch (Exception ex)
            {

            }
        }

        private void RegisterToChat()
        {
            if ((this._chatClient != null))
            {
                this._chatClient.Abort();
                this._chatClient = null;
            }

            ChatCallback cb = new ChatCallback();
            cb.SetHandler(this.HandleBroadcastForChat);

            InstanceContext context = new InstanceContext(cb);
            this._chatClient = new ChattingService.ChatServiceClient(context);            
            this._chatClient.RegisterToChat(User);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.RegisterToChat();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            this._chatClient.NotifyUsers(new ChatEvents()
            {
                Message = this.txtMsg.Text,
                UserName = User
            });
        }
    }
}
