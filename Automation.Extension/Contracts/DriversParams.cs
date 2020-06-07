using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Automation.Extension.Contracts
{
    [DataContract]
    public class DriversParams
    {
        [DataMember]
        public string Driver { get; set; }
        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public string Binaries { get; set; }
    }
}
