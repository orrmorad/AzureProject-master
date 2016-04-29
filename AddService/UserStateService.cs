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
            AddToDict inst = AddToDict.Instance;

            callback.NewUser(inst, user);
        }//kl
    }
}
