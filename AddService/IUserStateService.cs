using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace AddService
{
    [ServiceContract(CallbackContract = typeof(IUserStateServiceCallback))]
    public interface IUserStateService
    {
        [OperationContract]
        void Register();
    }
}
