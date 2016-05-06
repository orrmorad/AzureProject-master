using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.ObjectModel;

namespace AddService
{
    [ServiceContract(CallbackContract = typeof(IUserStateServiceCallback))]
    public interface IUserStateService
    {
        [OperationContract(IsOneWay = true)]
        void RegisterClient(string clientName);

        [OperationContract(IsOneWay = true)]
        void NotifyServer(EventDataType eventData);

        #region OLD CODE
        //[OperationContract]
        //void Register(string userName, AddToDict instance);
        #endregion

    }
}
