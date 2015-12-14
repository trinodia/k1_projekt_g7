using System.Collections.Generic;
using DataModel;
using BusinessLogic;
using System;

namespace Service
{
    public class ToDoService : IToDoService
    {
        public List<ToDo> GetToDoListByName(string name)
        {
            var toDoList = BusinessLogicLayer.GetToDoListByName(name);
            return toDoList;
        }

        public string AddToDo(string name, string description, bool finnished, DateTime createdDate, DateTime deadLine, int estimationTime)
        { 
            return BusinessLogicLayer.AddToDo(name, description, finnished, createdDate, deadLine, estimationTime);
        }
    }
}
