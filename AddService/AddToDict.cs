using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddService
{
    public class AddToDict
    {
        private static AddToDict _instance;
        public Dictionary<Guid, User> clientDictionary = new Dictionary<Guid, User>();

        private AddToDict() { }

        public static AddToDict Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AddToDict();
                return _instance;
            }
        }

        public void AddToDictionary(Guid id, User user)
        {
            clientDictionary.Add(id, user);
        }

        public void RemoveFromDictionary(Guid id)
        {
            clientDictionary.Remove(id);
        }
    }
}
