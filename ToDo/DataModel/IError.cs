using System;

namespace DataModel
{
    public interface IError
    {
        string ErrorMessage { get; set; }
        string ErrorType { get; set; }
    }
}
