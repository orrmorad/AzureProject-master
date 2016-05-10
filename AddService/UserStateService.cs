using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Collections.ObjectModel;
using AddService.DataTypes;

namespace AddService
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class UserStateService : IUserStateService
    {

        private static Dictionary<string, IUserStateServiceCallback> clients =
            new Dictionary<string, IUserStateServiceCallback>();

        private static Dictionary<string, IUserStateServiceCallback> ChatClients =
           new Dictionary<string, IUserStateServiceCallback>();

        private static object locker = new object();

        public void AskToChat(AskToChatTypes eventData, string userToChat)
        {
            lock (locker)
            {
                var inactiveClients = new List<string>();
                foreach (var client in ChatClients)
                {
                    //if (client.Key != eventData.ClientName)
                    //{
                    if (userToChat == client.Key)
                    {
                        try
                        {
                            client.Value.BroadcastToChatClient(eventData);
                        }
                        catch (Exception ex)
                        {
                            inactiveClients.Add(client.Key);
                        }
                    }
                    //}
                }

                if (inactiveClients.Count > 0)
                {
                    foreach (var client in inactiveClients)
                    {
                        clients.Remove(client);
                    }
                }
            }
        }

        public void NotifyServer(EventDataType eventData)
        {
            lock (locker)
            {
                var inactiveClients = new List<string>();
                foreach (var client in clients)
                {
                    //if (client.Key != eventData.ClientName)
                    //{
                    try
                    {
                        client.Value.BroadcastToClient(eventData);
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
                        clients.Remove(client);
                    }
                }
            }
        }

        public void RegisterClient(string clientName)
        {
            if (clientName != null && clientName != "")
            {
                try
                {
                    IUserStateServiceCallback callback =
                        OperationContext.Current.GetCallbackChannel<IUserStateServiceCallback>();
                    lock (locker)
                    {
                        //remove the old client
                        if (clients.Keys.Contains(clientName))
                            clients.Remove(clientName);
                        clients.Add(clientName, callback);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void RegisterChatAvailability(string clientName)
        {
            if (clientName != null && clientName != "")
            {
                try
                {
                    IUserStateServiceCallback callback =
                        OperationContext.Current.GetCallbackChannel<IUserStateServiceCallback>();
                    lock (locker)
                    {
                        //remove the old client
                        if (ChatClients.Keys.Contains(clientName))
                            ChatClients.Remove(clientName);
                        ChatClients.Add(clientName, callback);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        



        #region OLD CODE
        //private readonly List<IUserStateServiceCallback> callbacks = new List<IUserStateServiceCallback>();

        //private static object locker = new object();

        //private static Dictionary<string, IUserStateServiceCallback> clients =
        //    new Dictionary<string, IUserStateServiceCallback>();

        //public UserStateService()
        //{

        //}

        //public void Register(string userName, AddToDict instance)
        //{
        //    callbacks.Add(OperationContext.Current.GetCallbackChannel<IUserStateServiceCallback>());
        //    NotifyUsers(userName, instance);
        //}

        //public void NotifyUsers(string userName, AddToDict instance)
        //{
        //    foreach (var callback in callbacks)
        //    {
        //        callback.Message(userName, instance);
        //    }


        //}
        #endregion

    }
}
