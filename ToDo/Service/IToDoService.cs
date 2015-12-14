using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using DataModel;
using System;

namespace Service
{
    [ServiceContract]
    public interface IToDoService
    {
        [OperationContract]
        [WebGet]
        List<ToDo> GetToDoListByName(string name);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AddToDo(string name, string description, bool finnished, DateTime createdDate, DateTime deadLine, int estimationTime);

    }
}
