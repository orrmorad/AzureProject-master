using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AddService.DataTypes
{
    [ServiceContract]
    public class ChatEvents
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
