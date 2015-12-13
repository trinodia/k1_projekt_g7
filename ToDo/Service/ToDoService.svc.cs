using System.Collections.Generic;
using DataModel;
using BusinessLogic;

namespace Service
{
    public class ToDoService : IToDoService
    {
        public List<ToDo> GetToDoListByName(string name)
        {
            var toDoList = BusinessLogicLayer.GetToDoListByName(name);
            return toDoList;
        }
    }
}
