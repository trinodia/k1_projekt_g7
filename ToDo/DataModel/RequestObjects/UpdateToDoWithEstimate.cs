using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.RequestObjects
{
    [DataContract(Name = "UpdateToDoWithEstimate", Namespace = "Service")]
    public class UpdateToDoWithEstimate
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int estimationtime { get; set; }
    }
}
