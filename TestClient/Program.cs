﻿using AddService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TestClient;
using TestClient.StatusService;

namespace TestLoginClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //BL.Logic logic = BL.Logic.LogicInstance;
            
            //ObservableCollection<string> users = new ObservableCollection<string>();
            //AddToDict ins = AddToDict.Instance;
            //var svc1 = new TestClient.AddUserService.AddServiceClient();

            //InstanceContext callback = new InstanceContext(new StatusCallback());
            //ins = svc1.IsUserExist("noam", "1234");
            //UserStateServiceClient client = new UserStateServiceClient(callback);
            //client.Register("noam", ins);



            //foreach(var a in logic.OnlineUserNames)
            //{ Console.WriteLine(a); }

            //Console.Read();
            //client.Close();

            //svc1.InsertUser(1, "orr", "Orr", "Morad", "1234");
            //svc1.InsertUser(2, "noam", "Noam", "Caftori", "1234");
            //svc1.InsertUser(3, "client3", "Client1", "Last2", "1234");
            //svc1.InsertUser(4, "client4", "Client4", "Last3", "1234");
            //ins = svc1.IsUserExist("noam", "1234");
            //ins = svc1.IsUserExist("orr", "1234");



            //List<Model.User> onlineUsers = ins.clientDictionary.Select(u => u.Value).ToList();
            //List<Model.User> offlineUsers = svc1.GetOfflineUsers().ToList();
            ////var stat = new TestClient.StatusService.UserStateServiceClient();
            //var callback = new StatusCallback();
            //var instanceContext = new InstanceContext(callback);
            //var client = new UserStateServiceClient(instanceContext);
            //client.OpenSession();
            Console.ReadLine();
            //stat.OpenSession();


        }
    }
}
