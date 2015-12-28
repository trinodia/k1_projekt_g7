using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataModel
{
    [DataContract(Name = "ToDoList", Namespace = "Service")]
    public class ToDoList : DefaultReturnMessage
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Items")]
        public List<ToDo> Items { get; set; }

        [DataMember(Name = "Count")]
        public int Count { get; set; }

        public ToDoList()
        {
            Count = 0;
            Items = new List<ToDo>();
        }

    }
}
