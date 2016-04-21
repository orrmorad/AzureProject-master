using AddService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace TestClient
{
    public class StatusCallback : IUserStateServiceCallback
    {
        public void NewUser(User user)
        {
            Console.WriteLine("callback");
        }
    }
}
