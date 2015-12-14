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

        public string AddToDoList(string name)
        {

            try
            {
                BusinessLogicLayer.AddToDoList(name);
            }
            catch(ArgumentException argEx)
            {
                return argEx.Message;
            }
            catch
            {
                return "Något gick fel, försök igen.";
            }
            return "";
        }
    }
}
