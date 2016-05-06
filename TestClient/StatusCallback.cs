using AddService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TestClient
{
    public class StatusCallback : StatusService.IUserStateServiceCallback
    {




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
        public void Message(string userName, AddToDict instance)
        {
            throw new NotImplementedException();
        }
    }
}
