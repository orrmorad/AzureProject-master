using AddService.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AddService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ChatService : IChatService
    {

        private static Dictionary<string, IChatServiceCallback> chatUsers =
            new Dictionary<string, IChatServiceCallback>();
        private static object locker = new object();

        public void NotifyUsers(ChatEvents chatEvent)
        {
            lock (locker)
            {
                var inactiveClients = new List<string>();
                foreach (var client in chatUsers)
                {
                    //if (client.Key != chatEvent.UserName)
                    //{
                        try
                        {
                            client.Value.BroadcastToChatUsers(chatEvent);
                        }
                        catch (Exception ex)
                        {
                            inactiveClients.Add(client.Key);
                        }
                    //}
                }

                if (inactiveClients.Count > 0)
                {
                    foreach (var client in inactiveClients)
                    {
                        chatUsers.Remove(client);
                    }
                }
            }
        }

        public void RegisterToChat(string userName)
        {
            if (userName != null && userName != "")
            {
                try
                {
                    IChatServiceCallback callback =
                        OperationContext.Current.GetCallbackChannel<IChatServiceCallback>();
                    lock (locker)
                    {
                        //remove the old client
                        if (chatUsers.Keys.Contains(userName))
                            chatUsers.Remove(userName);
                        chatUsers.Add(userName, callback);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
