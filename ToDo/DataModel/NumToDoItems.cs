using System;
using System.Runtime.Serialization;

namespace DataModel
{
    [DataContract(Name = "NumToDoItems", Namespace = "Service")]
    public class NumToDoItems : DefaultReturnMessage
    {
        [DataMember(Name = "Count")]
        public int Count { get; set; }
    }
}
