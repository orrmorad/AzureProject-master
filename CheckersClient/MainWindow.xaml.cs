using CheckersClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using AddService;
using System.ServiceModel;
using CheckersClient.UserStatusService;
using System.Collections.ObjectModel;

namespace LoginClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddToDict ins;
        ObservableCollection<string> OnlineClients { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            OnlineClients = new ObservableCollection<string>();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var svc = new CheckersClient.LoginService.AddServiceClient();
            ins = svc.IsUserExist(txtUserName.Text, txtPassword.Password);
            string value = this.txtUserName.Text;
            Guid id = ins.clientDictionary.FirstOrDefault(x => x.Value.UserName == value).Key;
            if (ins.clientDictionary.Count != 0)
            {
                StartWindow window2 = new StartWindow(value, ins, id, svc);
                window2.Show();
                this.Close();
            }
            else
                MessageBox.Show("Login failed");
        }

        private ObservableCollection<string> OnlineUsers(AddToDict ins)
        {
            foreach (var userName in ins.clientDictionary)
            {
                OnlineClients.Add(userName.Value.UserName);
            }
            return OnlineClients;
        }
    }
}
