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
    public class AskToChatTypes
    {
        [DataMember]
        public string UserToAsk { get; set; }

        [DataMember]
        public string UserAsking { get; set; }
    }
}
