using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AddService
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(AddService));
            host.Open();

            //var host2 = new ServiceHost(typeof(UserStateService));
            //host2.Open();
            //Console.Read();

            //UserStateService state = new UserStateService();
            var host2 = new ServiceHost(typeof(UserStateService));
            host2.Open();
            //ServiceHost serviceHost = new ServiceHost(state);
            //serviceHost.Open();
            Console.WriteLine("Service started, press any key to quit");
            Console.ReadKey();
            //serviceHost.Close();


        }
    }
}
