using System;
using System.Runtime.Serialization;

namespace DataModel
{
    [DataContract(Name = "Base", Namespace = "Service")]
    public class DefaultReturnMessage : ISuccess, IError
    {
        [DataMember(Name = "Success")]
        public bool Success { get; set; }

        [DataMember(Name = "ErrorMessage")]
        public string ErrorMessage { get; set; }

        [DataMember(Name = "ErrorType")]
        public string ErrorType { get; set; }

    }
}
