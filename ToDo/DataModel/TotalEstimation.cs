using System;

namespace DataModel
{
    public class TotalEstimation : Base, IError
    {
        public int TotalMinutes { get; set; }
        public DateTime TimeCompleted { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorType { get; set; }
    }
}
