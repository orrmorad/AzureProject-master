﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AddService
{
    [ServiceContract]
    public class EventDataType
    {
        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public string EventMessage { get; set; }
    }
}
