using AddService.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AddService
{
    public interface IChatServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void BroadcastToChatUsers(ChatEvents eventData);
    }
}
