using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using DataModel;
using System;
using System.ComponentModel;
using DataModel.RequestObjects;

namespace Service
{
    [ServiceContract]
    public interface IToDoService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetToDoListByName/{name}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Gets all ToDoItems in list with supplied name.")]
        ToDoList GetToDoListByName(string name);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetToDoListByDone/{name}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Gets all finnished ToDoItems in list with supplied name.")]
        ToDoList GetToDoListByDone(string name);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetToDoListByVip/{name}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Gets all VIP ToDoItems in list with supplied name.")]
        ToDoList GetToDoListByVip(string name);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetNumberOfToDoItemsInList/{name}?finnished={finnished}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Gets number of ToDoItems in list with supplied name and finnished status.")]
        NumToDoItems GetNumberOfToDoItemsInList(string name, string finnished);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetTotalEstimation/{name}?includeFinnished={includeFinnished}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Gets totale estimationtime in list with supplied name. Option to include finnished items exists.")]
        TotalEstimation GetTotalEstimation(string name, string includeFinnished);

        [OperationContract]
        [WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Removes ToDoItem using supplied ID.")]
        DefaultReturnMessage DeleteToDoItem(int id);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Create a new ToDoList including first item in the list.")]
        DefaultReturnMessage AddToDoList(ToDo toDo);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Create a new ToDoItem for ToDoList supplied name.")]
        DefaultReturnMessage AddToDoItem(ToDo toDo);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Create a multiple ToDoItems for ToDoList supplied name.")]
        DefaultReturnMessage AddToDoItems(AddMultipleToDo toDo);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Update ToDoItem with new estimation.")]
        DefaultReturnMessage UpdateToDoItemWithEstimate(UpdateToDoWithEstimate estimate);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Update ToDoItem with new information.")]
        DefaultReturnMessage UpdateToDoItem(ToDo toDo);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Mark ToDoItem as finnished.")]
        DefaultReturnMessage FinishToDoItem(int id);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Mark ToDoItem as unfinnished.")]
        DefaultReturnMessage UnFinishToDoItem(int id);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Update ToDoItem with deadline.")]
        DefaultReturnMessage SetDeadLineToDoItem(SetDeadLineToDoItem newDeadLine);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetToDoListOrderedAscendingByDeadLine/{name}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [Description("Get ToDoList ordered ascending by deadline.")]
        ToDoList GetToDoListOrderedAscendingByDeadLine(string name);

    }
}
