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
        public bool IsUserExist(string userName, string password)
        {
            AddToDict inst = AddToDict.Instance;
            var exist = new BL.Logic();
            var getUser = new BL.Logic();
            bool b = exist.IsExist(userName, password);
            if (b)
            {
                User user = getUser.GetUser(userName);
                Guid key = Guid.NewGuid();
                inst.AddToDictionary(key, user);
                return true;
            }
            return false;
        }

        public void InsertUser(int id, string userName, string firstName, string lastName, string password)
        {
            var addUser = new BL.Logic();
            addUser.InsertUser(id, userName, firstName, lastName, password);
            Console.WriteLine("User added succefully");
        }
    }
}
