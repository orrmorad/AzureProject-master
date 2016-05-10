using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.ObjectModel;
using AddService.DataTypes;

namespace AddService
{
    [ServiceContract(CallbackContract = typeof(IUserStateServiceCallback))]
    public interface IUserStateService
    {
        [OperationContract(IsOneWay = true)]
        void RegisterClient(string clientName);

        [OperationContract(IsOneWay = true)]
        void NotifyServer(EventDataType eventData);

        [OperationContract(IsOneWay = true)]
        void AskToChat(AskToChatTypes eventData, string userToChat);

        [OperationContract(IsOneWay = true)]
        void RegisterChatAvailability(string clientName);

        #region OLD CODE
        //[OperationContract]
        //void Register(string userName, AddToDict instance);
        #endregion

    }
}
