using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace DataModel
{
    [DataContract(Name = "ToDo", Namespace = "Service")]
    public class ToDo
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(IsRequired = true, Name = "Name")]
        public string Name { get; set; }

        [DataMember(IsRequired = true, Name = "Description")]
        public string Description { get; set; }

        [DataMember(Name = "Finnished")]
        public bool Finnished { get; set; }

        [DataMember(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DataMember(Name = "DeadLine")]
        public DateTime? DeadLine { get; set; }

        [DataMember(Name = "EstimationTime")]
        public int EstimationTime { get; set; }

        public ToDo()
        {
            CreatedDate = DateTime.Now;
            DeadLine = new DateTime(1800, 1, 1);
            EstimationTime = -1;
        }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("You must supply a name for the list to add items to.");

            if (string.IsNullOrWhiteSpace(Description))
                throw new ArgumentException("You must supply a description to add to the list.");

            // If no deadline is provided, set a default deadline
            if(DeadLine == null)
                DeadLine = new DateTime(1800, 1, 1);

            if (EstimationTime <= 0)
                throw new ArgumentException("The Estimated time must be positive.");

            return true;
        }

    }
}
