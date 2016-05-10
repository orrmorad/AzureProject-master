using AddService.DataTypes;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AddService
{

    public interface IUserStateServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void BroadcastToClient(EventDataType eventData);

        [OperationContract(IsOneWay = true)]
        void BroadcastToChatClient(AskToChatTypes eventChat);

        #region OLD CODE
        //[OperationContract(IsOneWay = true)]
        //void Message(string userName, AddToDict instance);
        #endregion
    }
}
