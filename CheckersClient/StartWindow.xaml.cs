using AddService;
using AddService.DataTypes;
using CheckersClient.LoginService;
using CheckersClient.UserStatusService;
using Model;
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
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        AddToDict cache;
        public string UserName { get; set; }
        public string Header { get; set; }
        public Guid Id { get; set; }
        public List<User> OfflineUsers { get; set; }
        public ObservableCollection<string> OfflineUserNames { get; set; }
        AddServiceClient _svc;

        private string _userAskingToChat;
        private string _userAskedToChat;

        public StartWindow(string _userName, AddToDict _inst, Guid _id, AddServiceClient svc)
        {
            InitializeComponent();
            Id = _id;
            DataContext = this;
            Header = "Welcome " + _userName + "!";
            cache = _inst;
            UserName = _userName;
            Users = new ObservableCollection<string>();
            _svc = svc;
            LogicInstance = BL.Logic.Instance;
            this.RegisterClient();
            this._client.NotifyServer(new EventDataType()
            {
                ClientName = UserName,
                EventMessage = "Login"
            });           
        }


        private UserStateServiceClient _client;
        public BL.Logic LogicInstance { get; set; }
        public ObservableCollection<string> Users { get; set; }

        private delegate void HandleBroadcastCallback(object sender, EventArgs e);
        public void HandleBroadcast(object sender, EventArgs e)
        {
            EventDataType _event = (EventDataType)sender;

            if (_event.EventMessage == "Login")
            {
                if (Users.Count == 0)
                {
                    foreach (var user in cache.clientDictionary)
                    {
                        Users.Add(user.Value.UserName);
                    }
                }
                else
                    Users.Add(BL.Logic.Instance.Collection.LastOrDefault());
            }

            else if (_event.EventMessage == "Logout")
            {
                Users.Remove(_event.ClientName);
                OfflineUserNames.Add(_event.ClientName);
            }
        }

        private void RegisterClient()
        {
            if ((this._client != null))
            {
                this._client.Abort();
                this._client = null;
            }

            UserStatus cb = new UserStatus();
            cb.SetHandler(this.HandleBroadcast);
            cb.SetHandlerForChat(this.HandleBroadcastAskToChat);

            InstanceContext context = new InstanceContext(cb);
            this._client = new UserStateServiceClient(context);
            this._client.RegisterClient(UserName);
            this._client.RegisterChatAvailability(UserName);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

       

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cache = _svc.RemoveUser(UserName);
            this._client.NotifyServer(new AddService.EventDataType()
            {
                ClientName = UserName,
                EventMessage = "Logout"
            });
        }

        private void btnChat_Click(object sender, RoutedEventArgs e)
        {
            string _userToChat = this.lstbxOnline.SelectedItem.ToString();
            this._client.AskToChat(new AskToChatTypes
            {
                UserToAsk = _userToChat,
                UserAsking = UserName
            }, _userToChat);
            //_userAskingToChat = UserName;
            //_userAskedToChat = _userToChat;
            //LogicInstance.ChatUserList(_userAskingToChat, _userAskedToChat);
            //ChatWindow chatWindow = new ChatWindow();
            //chatWindow.Show();
           // this.Close();            
        }

        public void HandleBroadcastAskToChat(object sender, EventArgs e)
        {
            AskToChatTypes _event = (AskToChatTypes)sender;
            //MessageBox.Show(_event.UserAsking + " wants to chat with you");
            ChatWindow chatWindow1 = new ChatWindow(_event.UserAsking);
            ChatWindow chatWindow2 = new ChatWindow(_event.UserToAsk);
            chatWindow1.Show();
            this.Close();
            chatWindow2.Show();
            this.Close();
        }


    }
}
