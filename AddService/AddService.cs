using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;


namespace AddService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AddService" in both code and config file together.
    public class AddService : IAddService
    {
        public AddToDict inst = AddToDict.Instance;
        List<User> onlineUsers = new List<User>();
        // BL.Logic logic = new BL.Logic();
        public BL.Logic bl = BL.Logic.Instance;

        public AddToDict IsUserExist(string userName, string password)
        {
            //var exist = new BL.Logic();
            //var getUser = new BL.Logic();
            bool b = bl.IsExist(userName, password);
            if (b)
            {
                User user = bl.GetUser(userName);
                Guid key = Guid.NewGuid();
                inst.AddToDictionary(key, user);
                return inst;
            }
            return inst;
        }

        public void InsertUser(int id, string userName, string firstName, string lastName, string password)
        {
            //var addUser = new BL.Logic();
            bl.InsertUser(id, userName, firstName, lastName, password);
            Console.WriteLine("User added succefully");
        }


        public AddToDict RemoveUser(string userName)
        {
            Guid id = inst.clientDictionary.FirstOrDefault(x => x.Value.UserName == userName).Key;
            inst.RemoveFromDictionary(id);
            return inst;
        }


        public List<User> GetOfflineUsers()
        {
            List<User> onlineUsers = inst.clientDictionary.Select(u => u.Value).ToList();
            return bl.GetOfflineUsers(onlineUsers);
        }
    }
}
