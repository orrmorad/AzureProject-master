using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AddService
{
    
    public interface IUserStateServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void Message();        
    }
}
