using System;
using System.Runtime.Serialization;

namespace DataModel
{
    [DataContract(Name = "TotalEstimation", Namespace = "Service")]
    public class TotalEstimation : DefaultReturnMessage
    {
        [DataMember(Name = "TotalMinutes")]
        public int TotalMinutes { get; set; }

        [DataMember(Name = "TimeCompleted")]
        public DateTime TimeCompleted { get; set; }

    }
}
