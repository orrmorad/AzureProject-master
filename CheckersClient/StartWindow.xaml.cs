using AddService;
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

        public StartWindow(string _userName, AddToDict _inst)
        {
            InitializeComponent();
            DataContext = this;
            UserName = _userName;
            Inst = _inst;
            Header = "Hello " + UserName;

            Resources["Users"] = Inst.clientDictionary;

        }


    }
}
