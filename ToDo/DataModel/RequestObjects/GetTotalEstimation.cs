using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.RequestObjects
{
    [DataContract(Name = "GetTotalEstimation", Namespace = "Service")]
    public class GetTotalEstimation
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public bool includeFinnished { get; set; }
    }
}
