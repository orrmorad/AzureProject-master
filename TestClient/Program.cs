using System;
using System.Collections.Generic;
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
            //var svc1 = new TestClient.AddUserService.AddServiceClient();
            //svc1.InsertUser(1, "orr", "Orr", "Morad", "1234");
            //svc1.InsertUser(2, "noam", "Noam", "Caftori", "1234");
            //svc1.IsUserExist("noam", "1234");
            //var stat = new TestClient.StatusService.UserStateServiceClient();
            var callback = new StatusCallback();
            var instanceContext = new InstanceContext(callback);
            var client = new UserStateServiceClient(instanceContext);
            client.OpenSession();
            //stat.OpenSession();


        }
    }
}
