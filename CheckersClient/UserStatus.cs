using AddService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ServiceModel;
using AddService.DataTypes;

namespace CheckersClient
{
   // [CallbackBehavior(UseSynchronizationContext = false)]
    public class UserStatus : UserStatusService.IUserStateServiceCallback
    {
        BL.Logic LogicInstance = BL.Logic.Instance;
        private EventHandler _broadcastorCallBackHandler;

        

        public void SetHandler(EventHandler handler)
        {
            this._broadcastorCallBackHandler = handler;
        }

        public void BroadcastToClient(EventDataType eventData)
        {
            LogicInstance.UpdateOnlineList(eventData.ClientName);
            OnBroadcast(eventData);
        }

        private void OnBroadcast(object eventData)
        {
            this._broadcastorCallBackHandler.Invoke(eventData, null);
        }


        //***********************************************************************//

        private EventHandler _broadcastorCallBackHandlerForChat;
        public void SetHandlerForChat(EventHandler handler)
        {
            this._broadcastorCallBackHandlerForChat = handler;
        }

        public void BroadcastToChatClient(AskToChatTypes eventChat)
        {
            LogicInstance.ChatUserList(eventChat.UserAsking, eventChat.UserToAsk);
            OnBroadcastToChat(eventChat);
        }

        private void OnBroadcastToChat(object eventChat)
        {
            this._broadcastorCallBackHandlerForChat.Invoke(eventChat, null);
        }


        #region OLD CODE
        //BL.Logic logic = BL.Logic.LogicInstance;

        //public void Message(string userName, AddToDict instance)
        //{
        //    if (logic.OnlineUserNames.Count == 0)
        //    {
        //        foreach (var user in instance.clientDictionary)
        //        {
        //            logic.OnlineUserNames.Add(user.Value.UserName);
        //        }
        //    }
        //    else
        //        logic.UpdateOnlineList(userName);
        //}
        #endregion
    }
}
