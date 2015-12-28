using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace DataModel
{
    [DataContract(Name = "AddMultipleToDo", Namespace = "Service")]
    public class AddMultipleToDo : DefaultReturnMessage
    {
        [DataMember(IsRequired = true, Name = "Name")]
        public string Name { get; set; }

        [DataMember(IsRequired = true, Name = "Descriptions")]
        public string Descriptions { get; set; }

        [DataMember(Name = "Finnished")]
        public bool Finnished { get; set; }

        [DataMember(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DataMember(Name = "DeadLine")]
        public DateTime? DeadLine { get; set; }

        [DataMember(Name = "EstimationTime")]
        public int EstimationTime { get; set; }

        public AddMultipleToDo()
        {
            CreatedDate = DateTime.Now;
            DeadLine = new DateTime(1800, 1, 1);
        }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("You must supply a name for the list to add items to.");

            if (string.IsNullOrWhiteSpace(Descriptions))
                throw new ArgumentException("You must supply at least one description to add to the list.");

            // If no deadline is provided, set a default deadline
            if(DeadLine == null)
                DeadLine = new DateTime(1800, 1, 1);

            return true;
        }

    }
}
