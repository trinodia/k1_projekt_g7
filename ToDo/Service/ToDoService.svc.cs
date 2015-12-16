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
            var toDoList = new List<ToDo>();
            try
            {
                toDoList = BusinessLogicLayer.GetToDoListByName(name);
                return toDoList;
            }
            catch (ArgumentException argEx)
            {
                //TODO: Write argEx.Message to browser;
                return toDoList;
            }
            catch (Exception)
            {
                //TODO: Write "Unknown exception." to browser.
            return toDoList;
        }
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
            catch (Exception)
            {
                //TODO: Write "Unknown exception." to browser.
                return "Unknown exception.";
            }
            //TODO: Write "" to browser.
            return "";
        }
    }
}
