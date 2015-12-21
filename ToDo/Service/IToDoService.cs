﻿using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using DataModel;
using System.IO;
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
        string AddToDoList(string name, string description, DateTime? deadline, int estimationtime);

        [OperationContract]
        [WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string DeleteToDoItem(int id);

    }
}
