using System.Collections.Generic;
using DataModel;
using BusinessLogic;
using System;

namespace Service
{
    public class ToDoService : IToDoService
    {
        public DefaultReturnMessage AddToDoItem(ToDo toDo)
        {
            try
            {
                BusinessLogicLayer.AddToDoEntry(toDo);
                return new DefaultReturnMessage() { Success = true };
            }
            catch (Exception ex)
            {
                return new DefaultReturnMessage() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public DefaultReturnMessage DeleteToDoItem(int id)
        {
            try
            {
                BusinessLogicLayer.DeleteToDoItemById(id);
                return new DefaultReturnMessage() { Success = true };
            }
            catch (Exception ex)
            {
                return new DefaultReturnMessage() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
            //TODO: Write "" to browser.
        }

        public DefaultReturnMessage FinishToDoItem(int id)
        {
            try
            {
                BusinessLogicLayer.FinishToDoItem(id);
                return new DefaultReturnMessage() { Success = true };
            }
            catch (Exception ex)
            {
                return new DefaultReturnMessage() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public DefaultReturnMessage UnFinishToDoItem(int id)
        {
            try
            {
                BusinessLogicLayer.UnFinishToDoItem(id);
                return new DefaultReturnMessage() { Success = true };
            }
            catch (Exception ex)
            {
                return new DefaultReturnMessage() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public DefaultReturnMessage SetDeadLineToDoItem(int id, DateTime newDeadLine)
        {
            try
            {
                BusinessLogicLayer.SetDeadLineToDoItem(id, newDeadLine);
                return new DefaultReturnMessage() { Success = true };
            }
            catch (Exception ex)
            {
                return new DefaultReturnMessage() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public DefaultReturnMessage UpdateToDoItem(ToDo toDo)
        {
            try
            {
                BusinessLogicLayer.UpdateToDoItem(toDo);
                return new DefaultReturnMessage() { Success = true };
            }
            catch (Exception ex)
            {
                return new DefaultReturnMessage() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public DefaultReturnMessage AddToDoItems(AddMultipleToDo toDos)
        {
            try
            {
                BusinessLogicLayer.AddToDoEntries(toDos);
                return new DefaultReturnMessage() { Success = true };
            }
            catch (Exception ex)
            {
                return new DefaultReturnMessage() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public ToDoList GetToDoListByName(string name)
        {
            try
            {
                return BusinessLogicLayer.GetToDoListByName(name);
            }
            catch (Exception ex)
            {
                return new ToDoList() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public DefaultReturnMessage AddToDoList(ToDo toDo)
        {
            try
            {
                BusinessLogicLayer.AddToDoList(toDo);
                return new DefaultReturnMessage() { Success = true };
            }
            catch (Exception ex)
            {
                return new DefaultReturnMessage() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public ToDoList GetToDoListByDone(string name)
        {
            try
            {
                return BusinessLogicLayer.GetToDoListByDone(name);
            }
            catch (Exception ex)
            {
                return new ToDoList() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public NumToDoItems GetNumberOfToDoItemsInList(string name, bool finnished)
        {
            try
            {
                return BusinessLogicLayer.GetNumberOfToDoItemsInList(name, finnished);
            }
            catch (Exception ex)
            {
                return new NumToDoItems() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString(), Count = 0 };
            }
        }

        public ToDoList GetToDoListByVip(string name)
        {
            try
            {
                return BusinessLogicLayer.GetToDoListByVip(name);
            }
            catch (Exception ex)
            {
                return new ToDoList() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public ToDoList GetToDoListOrderedAscendingByDeadLine(string name)
        {
            try
            {
                return BusinessLogicLayer.GetToDoListOrderedAscendingByDeadLine(name);
            }
            catch (Exception ex)
            {
                return new ToDoList() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public TotalEstimation GetTotalEstimation(string name, bool includeFinnished = false)
        {
            try
            {
                return BusinessLogicLayer.GetTotalEstimation(name, includeFinnished);
            }
            catch (Exception ex)
            {
                return new TotalEstimation() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public DefaultReturnMessage UpdateToDoItemWithEstimate(int id, int estimationtime)
        {
            try
            {
                BusinessLogicLayer.UpdateToDoItemWithEstimate(id, estimationtime);
                return new DefaultReturnMessage() { Success = true };
            }
            catch (Exception ex)
            {
                return new DefaultReturnMessage() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }
    }
}
