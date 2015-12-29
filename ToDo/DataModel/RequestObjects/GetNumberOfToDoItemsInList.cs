using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.RequestObjects
{
    [DataContract]
    public class GetNumberOfToDoItemsInList
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public bool finnished { get; set; }
    }
}
