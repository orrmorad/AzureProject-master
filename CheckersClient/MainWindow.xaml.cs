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

namespace LoginClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddToDict ins;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var svc = new CheckersClient.LoginService.AddServiceClient();
            ins = svc.IsUserExist(txtUserName.Text, txtPassword.Password);
            string value = this.txtUserName.Text;
            if (ins != null)
            {
                
                StartWindow window2 = new StartWindow(value, ins);
                window2.Show();
                this.Close();
            }
            else
                MessageBox.Show("Login failed");
        }
    }
}
