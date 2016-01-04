using System.Collections.Generic;
using DataModel;
using DataAccess;
using System;
using System.Linq;
using DataModel.RequestObjects;

namespace BusinessLogic
{
    public class BusinessLogicLayer
    {
        /// <summary>
        /// Gets a specific ToDoItem by ID
        /// </summary>
        /// <param name="id">ToDoItems ID</param>
        /// <returns>Requested ToDoItem</returns>
        public static ToDo GetToDoItemById(int id)
        {
            var dbSession = new DataAccessLayer();

            var toDoItem = dbSession.GetToDoById(id); // GetToDoById includes check if item exists. Throws exception if it does not exist.

            return toDoItem;
        }

        /// <summary>
        /// Delete a ToDoItem by ID
        /// </summary>
        /// <param name="id">ToDoItems ID</param>
        public static void DeleteToDoItemById(int id)
        {
            var dbSession = new DataAccessLayer();
            
            dbSession.GetToDoById(id); // GetToDoById includes check if item exists. Throws exception if it does not exist.

            dbSession.DeleteToDo(id);
        }

        /// <summary>
        /// Sets a ToDoItem as Finnished
        /// </summary>
        /// <param name="id">ToDoItems ID</param>
        public static void FinishToDoItem(int id)
        {
            var dbSession = new DataAccessLayer();

            // GetToDoById includes check if item exists. Throws exception if it does not exist.
            var toDoItemToFinnish = dbSession.GetToDoById(id);

            if (!toDoItemToFinnish.Finnished)
                toDoItemToFinnish.Finnished = true;

            dbSession.UpdateToDo(toDoItemToFinnish);
        }

        /// <summary>
        /// Sets a ToDoItem to not Finnished
        /// </summary>
        /// <param name="id">ToDoItems ID</param>
        public static void UnFinishToDoItem(int id)
        {
            var dbSession = new DataAccessLayer();

            // GetToDoById includes check if item exists. Throws exception if it does not exist.
            var toDoItemToFinnish = dbSession.GetToDoById(id);

            if (toDoItemToFinnish.Finnished)
                toDoItemToFinnish.Finnished = false;

            dbSession.UpdateToDo(toDoItemToFinnish);
        }

        /// <summary>
        /// Update ToDoItem with a deadline
        /// </summary>
        /// <param name="id">ToDoItems ID</param>
        /// <param name="newDeadLine">Deadline to set</param>
        public static void SetDeadLineToDoItem(int id, DateTime newDeadLine)
        {
            var dbSession = new DataAccessLayer();

            // GetToDoById includes check if item exists. Throws exception if it does not exist.
            var toDoItemToUpdateDeadLineFor = dbSession.GetToDoById(id);

            toDoItemToUpdateDeadLineFor.DeadLine = newDeadLine;

            dbSession.UpdateToDo(toDoItemToUpdateDeadLineFor);
        }

        /// <summary>
        /// Gets a list of ToDoItems by the lists name
        /// </summary>
        /// <param name="name">ToDoLists name</param>
        /// <returns>ToDoList object</returns>
        public static ToDoList GetToDoListByName(string name)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            return new ToDoList() { Success = true, Count = toDoList.Count, Name = toDoList.First().Name, Items = toDoList };
        }

        /// <summary>
        /// Create a new ToDoList
        /// </summary>
        /// <param name="toDo">First ToDoItem in the list to create</param>
        public static void AddToDoList(ToDo toDo)
        {
            if (toDo.Validate())
            {
                if (toDo.Name.Length < 6)
                    throw new ArgumentException("The name of the list most be at least 6 chars.");

                var dbSession = new DataAccessLayer();

                if (dbSession.GetToDoListByName(toDo.Name).Count > 0)
                    throw new ArgumentException("A list with this name already exists and the name of a list most be unique.");

                dbSession.AddToDo(toDo);
            }
        }

        /// <summary>
        /// Create ToDoItem for existing list
        /// </summary>
        /// <param name="toDo">ToDoItem to add</param>
        public static void AddToDoItem(ToDo toDo)
        {
            if (toDo.Validate())
            {
                var dbSession = new DataAccessLayer();

                if (!dbSession.GetToDoListByName(toDo.Name).Any())
                    throw new ArgumentException("A list must be created first.");

                dbSession.AddToDo(toDo);
            }
        }

        /// <summary>
        /// Create multiple ToDoItems for existing list
        /// </summary>
        /// <param name="toDos">ToDoItems to create by using comma seperated Descriptions</param>
        public static void AddToDoItems(AddMultipleToDo toDos)
        {
            if (toDos.Validate())
            {
                var dbSession = new DataAccessLayer();

                if (!dbSession.GetToDoListByName(toDos.Name).Any())
                    throw new ArgumentException("A list must be created first.");

                string[] descs = toDos.Descriptions.Split(',');

                foreach (var desc in descs)
                {
                    var newToDo = new ToDo()
                    {
                        Name = toDos.Name,
                        Description = desc.Trim(),
                        Finnished = false,
                        CreatedDate = DateTime.Now,
                        DeadLine = (DateTime)toDos.DeadLine,
                        EstimationTime = toDos.EstimationTime
                    };

                    dbSession.AddToDo(newToDo);
                }
            }
        }

        /// <summary>
        /// Get ToDoItems in list that is Finnished
        /// </summary>
        /// <param name="name">Name of list</param>
        /// <returns>ToDoList object</returns>
        public static ToDoList GetToDoListByDone(string name)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            toDoList.RemoveAll(x => x.Finnished == false);

            return new ToDoList() { Success = true, Count = toDoList.Count, Name = toDoList.First().Name, Items = toDoList };
        }

        /// <summary>
        /// Gets number of ToDoItems in list
        /// </summary>
        /// <param name="name">Name of list</param>
        /// <param name="finnished">Count finnished or unfinnished items</param>
        /// <returns></returns>
        public static NumToDoItems GetNumberOfToDoItemsInList(string name, bool finnished)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            // return how many items that was removed
            return new NumToDoItems() { Success = true, Count = toDoList.RemoveAll(x => x.Finnished == finnished) };
        }

        /// <summary>
        /// Update ToDoItem with new information
        /// </summary>
        /// <param name="toDo">ToDoItem to update, new information already set in item and ID set to existing one in DB</param>
        public static void UpdateToDoItem(ToDo toDo)
        {
            if (toDo.Validate())
            {
                var dbSession = new DataAccessLayer();
                dbSession.UpdateToDo(toDo);
            }
        }

        /// <summary>
        /// Get ToDoItems in list that is important
        /// </summary>
        /// <param name="name">Name of list</param>
        /// <returns>ToDoList object</returns>
        public static ToDoList GetToDoListByVip(string name)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            toDoList.RemoveAll(x => x.Description.EndsWith("!") != true);

            return new ToDoList() { Success = true, Count = toDoList.Count, Name = toDoList.First().Name, Items = toDoList };
        }

        /// <summary>
        /// Update ToDoItem with estimate
        /// </summary>
        /// <param name="id">ToDoItems ID</param>
        /// <param name="estimationtime">Estimationtime to update with</param>
        public static void UpdateToDoItemWithEstimate(int id, int estimationtime)
        {
            var dbSession = new DataAccessLayer();

            var toDoItem = dbSession.GetToDoById(id);

            toDoItem.EstimationTime = estimationtime;

            dbSession.UpdateToDo(toDoItem);
        }

        /// <summary>
        /// Get total estimation of ToDoItems and possible Date when it is completed
        /// </summary>
        /// <param name="name">Name of list to fetch estimation for</param>
        /// <param name="includeFinnished">Include finnished items in estimate</param>
        /// <returns>TotalEstimation object</returns>
        public static TotalEstimation GetTotalEstimation(string name, bool includeFinnished)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            if (!includeFinnished)
                toDoList.RemoveAll(x => x.Finnished);

            var totalEstimation = toDoList.Select(x => x.EstimationTime).Sum();

            return new TotalEstimation() { Success = true, TotalMinutes = totalEstimation, TimeCompleted = DateTime.Now.AddMinutes(totalEstimation) };
        }

        /// <summary>
        /// Get ToDoItems in list ordered by deadline ascending
        /// </summary>
        /// <param name="name">Name of list</param>
        /// <returns>ToDoList object</returns>
        public static ToDoList GetToDoListOrderedAscendingByDeadLine(string name)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            var toDoListOrderedAscendingByDeadLine = toDoList.OrderBy(o => o.DeadLine).ToList();

            return new ToDoList() { Name = toDoListOrderedAscendingByDeadLine.First().Name, Count = toDoListOrderedAscendingByDeadLine.Count, Items = toDoListOrderedAscendingByDeadLine, Success = true };
        }
    }

}


