using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.RequestObjects
{
    [DataContract(Name = "SetDeadLineToDoItem", Namespace = "Service")]
    public class SetDeadLineToDoItem
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public DateTime newDeadLine { get; set; }
    }
}
