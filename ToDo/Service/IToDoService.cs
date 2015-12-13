using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using DataModel;

namespace Service
{
    [ServiceContract]
    public interface IToDoService
    {
        [OperationContract]
        [WebGet]
        List<ToDo> GetToDoListByName(string name);
    }
}
