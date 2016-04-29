using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AddService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAddService" in both code and config file together.
    [ServiceContract]
    public interface IAddService
    {
        [OperationContract]
        void InsertUser(int id, string userName, string firstName, string lastName, string password);

        [OperationContract]
        AddToDict IsUserExist(string userName, string password);
    }
}
