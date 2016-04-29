using AddService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace CheckersClient
{
    public class UserStatus : IUserStateServiceCallback
    {
        public void NewUser(AddToDict users, User user)
        {
            
        }
    }
}
