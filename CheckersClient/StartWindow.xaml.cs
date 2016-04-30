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
        public string UserName { get; set; }
        public string Header { get; set; }
        public AddToDict Inst { get; set; }
        public List<Model.User> OfflineUsers { get; set; }
        public List<string> OfflineUserNames { get; set; }

        LoginService.AddServiceClient svc;

        public StartWindow(string _userName, AddToDict _inst)
        {
            InitializeComponent();
            DataContext = this;
            OfflineUserNames = new List<string>();
            UserName = _userName;
            Inst = _inst;
            Header = "Hello " + UserName;
            Resources["Users"] = Inst.clientDictionary;
        }

        public void OfflineUserList()
        {
            OfflineUsers = svc.GetOfflineUsers().ToList();
            OfflineUsers.ForEach(user => OfflineUserNames.Add(user.UserName));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            svc = new LoginService.AddServiceClient();            
            OfflineUserList();                     
        }
    }
}
