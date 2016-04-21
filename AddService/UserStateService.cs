using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace AddService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class UserStateService : IUserStateService
    {
        public static IUserStateServiceCallback callback;
        public void OpenSession()
        {
            Console.WriteLine("Session is opened");
            Model.User user = null;

            callback = OperationContext.Current.GetCallbackChannel<IUserStateServiceCallback>();
            //using (var context = new DataContext())
            //{
            //    user = context.Users.Where((u) => u.UserName == "orr").FirstOrDefault();
            //}

            callback.NewUser(user);
        }//kl
    }
}
