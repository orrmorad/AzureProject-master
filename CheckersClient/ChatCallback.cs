using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddService.DataTypes;

namespace CheckersClient
{
    public class ChatCallback : ChattingService.IChatServiceCallback
    {
        BL.Logic LogicInstance = BL.Logic.Instance;
        private EventHandler _ChatCallBackHandler;

        public void SetHandler(EventHandler chatHandler)
        {
            this._ChatCallBackHandler = chatHandler;
        }


        public void BroadcastToChatUsers(ChatEvents eventData)
        {
            OnBroadcastToChatUsers(eventData);
        }

        private void OnBroadcastToChatUsers(object eventData)
        {
            this._ChatCallBackHandler.Invoke(eventData, null);
        }
    }
}
