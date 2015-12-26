using System.Collections.Generic;
using DataModel;
using BusinessLogic;
using System;

namespace Service
{
    public class ToDoService : IToDoService
    {
        public string AddToDoEntry(string name, string description, DateTime deadline, int estimationtime)
        {
            try
            {
                BusinessLogicLayer.AddToDoEntry(name, description, deadline, estimationtime);
            }
            catch (NullReferenceException nullEx)
            {
                return nullEx.Message;
            }
            catch (ArgumentException argEx)
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

        public string DeleteToDoItem(int id)
        {
            try
            {
                BusinessLogicLayer.DeleteToDoItemById(id);
            }
            catch (ArgumentException argEx)
            {
                return argEx.Message;
            }
            catch (Exception)
            {
                //TODO: Write "Unknown exception." to browser.
                return "Unhandled exception.";
            }
            //TODO: Write "" to browser.
            return "";
        }

        public string FinishToDoItem(int id)
        {
            try
            {
                BusinessLogicLayer.FinishToDoItem(id);
            }
            catch (NullReferenceException nullEx)
            {
                return nullEx.Message;
            }
            catch (ArgumentException argEx)
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

        public string UnFinishToDoItem(int id)
        {
            try
            {
                BusinessLogicLayer.UnFinishToDoItem(id);
            }
            catch (NullReferenceException nullEx)
            {
                return nullEx.Message;
            }
            catch (ArgumentException argEx)
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

        public string SetDeadLineToDoItem(int id, DateTime newDeadLine)
        {
            try
            {
                BusinessLogicLayer.SetDeadLineToDoItem(id, newDeadLine);
            }
            catch (NullReferenceException nullEx)
            {
                return nullEx.Message;
            }
            catch (ArgumentException argEx)
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

        public void UpdateToDoItem(ToDo todoitem)
        {
            try
            {
                BusinessLogicLayer.UpdateToDoItem(todoitem);
                
            }
            catch (ArgumentException argEx)
            {
                //TODO: Write argEx.Message to browser;
                //return toDoList;
            }
            catch (Exception)
            {
                //TODO: Write "Unknown exception." to browser.
                //return toDoList;
            }
        }

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

        public string AddToDoList(string name, string description, DateTime? deadline, int estimationtime)
        {
            try
            {
                BusinessLogicLayer.AddToDoList(name, description, deadline, estimationtime);
            }
            catch (NullReferenceException nullEx)
            {
                return nullEx.Message;
            }
            catch (ArgumentException argEx)
            {
                return argEx.Message;
            }
            catch (Exception)
            {
                //TODO: Write "Unknown exception." to browser.
                return "Unhandled exception.";
            }
            //TODO: Write "" to browser.
            return "";
        }

        public List<ToDo> GetToDoListByDone(string name)
        {
            var toDoList = new List<ToDo>();
            try
            {
                toDoList = BusinessLogicLayer.GetToDoListByDone(name);
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

        public int GetNumberOfToDoItemsInList(string name, bool finnished)
        {
            try
            {
                return BusinessLogicLayer.GetNumberOfToDoItemsInList(name, finnished);
            }
            catch (ArgumentException argEx)
            {
                //TODO: Write argEx.Message to browser;
                return -1;
            }
            catch (Exception)
            {
                //TODO: Write "Unknown exception." to browser.
                return -1;
            }
        }

        public List<ToDo> GetToDoListByVip(string name)
        {
            var toDoList = new List<ToDo>();
            try
            {
                toDoList = BusinessLogicLayer.GetToDoListByVip(name);
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

        public List<ToDo> GetToDoListOrderedAscendingByDeadline(string name)
        {
            var toDoList = new List<ToDo>();
            try
            {
                toDoList = BusinessLogicLayer.GetToDoListOrderedAscendingByDeadline(name);
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
    }
}
