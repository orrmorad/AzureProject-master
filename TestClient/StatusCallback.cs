using AddService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace TestClient
{
    public class StatusCallback : StatusService.IUserStateServiceCallback
    {
        public void Message()
        {
            Console.WriteLine("User is online");
        }
    }
}
