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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class UserStateService : IUserStateService
    {
        private readonly List<IUserStateServiceCallback> callbacks = new List<IUserStateServiceCallback>();

        public UserStateService()
        {

        }

        public void Register()
        {
            callbacks.Add(OperationContext.Current.GetCallbackChannel<IUserStateServiceCallback>());
            NotifyUsers();
        }

        private void NotifyUsers()
        {
            foreach (var callback in callbacks)
            {
                callback.Message();
            }
        }
    }
}
