using System.Collections.Generic;
using DataModel;
using BusinessLogic;
using System;
using System.IO;
using System.ServiceModel.Web;

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

        public List<ToDo> GetToDoListByVIP(string name)
        {
            var toDoList = new List<ToDo>();
            try
            {
                toDoList = BusinessLogicLayer.GetToDoListByVIP(name);
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
    }
}
