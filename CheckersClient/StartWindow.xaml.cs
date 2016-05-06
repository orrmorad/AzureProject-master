using AddService;
using CheckersClient.UserStatusService;
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

        public StartWindow(string _userName, AddToDict _inst)
        {
            InitializeComponent();
            DataContext = this;
            Header = "Welcome" + _userName + "!";
            cache = _inst;
            UserName = _userName;
            Users = new ObservableCollection<string>();
            this.RegisterClient();
            this._client.NotifyServer(new EventDataType()
            {
                ClientName = UserName,
                EventMessage = "message"
            });
            #region OLD CODE
            //InstanceContext callback = new InstanceContext(new UserStatus());
            //UserStateServiceClient client = new UserStateServiceClient(callback);
            //Inst = _inst;
            //client.Register(_userName, Inst);
            //LogicInstance = BL.Logic.LogicInstance;

            //DataContext = this;            
            //OfflineUserNames = new List<string>();
            //OnlineUsers = new ObservableCollection<string>();
            //OnlineUserList();
            //UserName = _userName;           
            //Header = "Hello " + UserName;                      
            #endregion
        }


        private UserStateServiceClient _client;
        public BL.Logic LogicInstance { get; set; }
        public ObservableCollection<string> Users { get; set; }

        private delegate void HandleBroadcastCallback(object sender, EventArgs e);
        public void HandleBroadcast(object sender, EventArgs e)
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

        private void RegisterClient()
        {
            if ((this._client != null))
            {
                this._client.Abort();
                this._client = null;
            }

            UserStatus cb = new UserStatus();
            cb.SetHandler(this.HandleBroadcast);

            InstanceContext context = new InstanceContext(cb);
            this._client = new UserStateServiceClient(context);
            this._client.RegisterClient(Guid.NewGuid().ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.RegisterClient();
            //this._client.NotifyServer(new EventDataType()
            //{
            //    ClientName = UserName,
            //    EventMessage = "message"
            //});
        }






        #region OLD CODE

        //    public string UserName { get; set; }
        //    public string Header { get; set; }
        //    public AddToDict Inst { get; set; }
        //    public List<Model.User> OfflineUsers { get; set; }

        //    public BL.Logic LogicInstance { get; set; }

        //    public List<string> OfflineUserNames { get; set; }
        //    public ObservableCollection<string> OnlineUsers { get; set; }

        //    LoginService.AddServiceClient svc;

        //    public void OfflineUserList()
        //    {
        //        OfflineUsers = svc.GetOfflineUsers().ToList();
        //        OfflineUsers.ForEach(user => OfflineUserNames.Add(user.UserName));
        //    }

        //    public void OnlineUserList()
        //    {
        //        foreach(var user in LogicInstance.OnlineUserNames)
        //        {
        //            OnlineUsers.Add(user);                
        //        }

        //    }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //    {
        ////        svc = new LoginService.AddServiceClient();
        ////        OfflineUserList();
        ////        OnlineUserList();
        //    } 
        #endregion
    }
}
