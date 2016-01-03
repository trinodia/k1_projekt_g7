using System.Collections.Generic;
using DataModel;
using BusinessLogic;
using System;
using DataModel.RequestObjects;

namespace Service
{
    public class ToDoService : IToDoService
    {
        public DefaultReturnMessage AddToDoItem(ToDo toDo)
        {
            try
            {
                BusinessLogicLayer.AddToDoItem(toDo);
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

        public DefaultReturnMessage SetDeadLineToDoItem(SetDeadLineToDoItem newDeadLine)
        {
            try
            {
                BusinessLogicLayer.SetDeadLineToDoItem(newDeadLine.id, newDeadLine.newDeadLine);
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
                BusinessLogicLayer.AddToDoItems(toDos);
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

        public NumToDoItems GetNumberOfToDoItemsInList(string name, string finnished)
        {
            try
            {
                bool _finnished = false;
                bool.TryParse(finnished, out _finnished);

                return BusinessLogicLayer.GetNumberOfToDoItemsInList(name, _finnished);
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

        public TotalEstimation GetTotalEstimation(string name, string includeFinnished)
        {
            try
            {
                bool _includeFinnished = false;
                bool.TryParse(includeFinnished, out _includeFinnished);

                return BusinessLogicLayer.GetTotalEstimation(name, _includeFinnished);
            }
            catch (Exception ex)
            {
                return new TotalEstimation() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }

        public DefaultReturnMessage UpdateToDoItemWithEstimate(UpdateToDoWithEstimate estimate)
        {
            try
            {
                BusinessLogicLayer.UpdateToDoItemWithEstimate(estimate.id, estimate.estimationtime);
                return new DefaultReturnMessage() { Success = true };
            }
            catch (Exception ex)
            {
                return new DefaultReturnMessage() { Success = false, ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };
            }
        }
    }
}
