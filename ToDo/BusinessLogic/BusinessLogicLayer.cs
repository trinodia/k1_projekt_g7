using System.Collections.Generic;
using DataModel;
using DataAccess;
using System;
using System.Linq;

namespace BusinessLogic
{
    public class BusinessLogicLayer
    {
        public static ToDo GetToDoItemById(int id)
        {
            var dbSession = new DataAccessLayer();

            var toDoItem = dbSession.GetToDoById(id);

            return toDoItem;
        }

        public static ToDoList GetToDoListByName(string name)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            return new ToDoList() { Success = true, Count = toDoList.Count, Name = toDoList.First().Name, Items = toDoList };
        }

        public static void DeleteToDoItemById(int id)
        {
            var dbSession = new DataAccessLayer();

            // GetToDoById includes check if item exists. Throws exception if it does not exist.
            dbSession.GetToDoById(id);

            dbSession.DeleteToDo(id);
        }

        public static void FinishToDoItem(int id)
        {
            var dbSession = new DataAccessLayer();

            // GetToDoById includes check if item exists. Throws exception if it does not exist.
            var toDoItemToFinnish = dbSession.GetToDoById(id);

            if (!toDoItemToFinnish.Finnished)
                toDoItemToFinnish.Finnished = true;

            dbSession.UpdateToDo(toDoItemToFinnish);
        }

        public static void UnFinishToDoItem(int id)
        {
            var dbSession = new DataAccessLayer();

            // GetToDoById includes check if item exists. Throws exception if it does not exist.
            var toDoItemToFinnish = dbSession.GetToDoById(id);

            if (toDoItemToFinnish.Finnished)
                toDoItemToFinnish.Finnished = false;

            dbSession.UpdateToDo(toDoItemToFinnish);
        }

        public static void SetDeadLineToDoItem(int id, DateTime newDeadLine)
        {
            var dbSession = new DataAccessLayer();

            // GetToDoById includes check if item exists. Throws exception if it does not exist.
            var toDoItemToUpdateDeadLineFor = dbSession.GetToDoById(id);

            toDoItemToUpdateDeadLineFor.DeadLine = newDeadLine;

            dbSession.UpdateToDo(toDoItemToUpdateDeadLineFor);
        }

        public static void AddToDoList(ToDo toDo)
        {
            if (toDo.Validate())
            {

                var dbSession = new DataAccessLayer();

                if (dbSession.GetToDoListByName(toDo.Name).Count > 0)
                    throw new ArgumentException("A list with this name already exists and the name of a list most be unique.");

                dbSession.AddToDo(toDo);
            }
        }

        public static void AddToDoEntry(ToDo toDo)
        {
            if (toDo.Validate())
            {
                var dbSession = new DataAccessLayer();

                if (!dbSession.GetToDoListByName(toDo.Name).Any())
                    throw new ArgumentException("A list must be created first.");

                dbSession.AddToDo(toDo);
            }
        }

        public static void AddToDoEntries(AddMultipleToDo toDos)
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

        public static ToDoList GetToDoListByDone(string name)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            toDoList.RemoveAll(x => x.Finnished == false);

            return new ToDoList() { Success = true, Count = toDoList.Count, Name = toDoList.First().Name, Items = toDoList };
        }

        public static NumToDoItems GetNumberOfToDoItemsInList(string name, bool finnished)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            // return how many items that was removed
            return new NumToDoItems() { Success = true, Count = toDoList.RemoveAll(x => x.Finnished == finnished) };
        }

        public static void UpdateToDoItem(ToDo toDo)
        {
            if (toDo.Validate())
            {
                var dbSession = new DataAccessLayer();
                dbSession.UpdateToDo(toDo);
            }
        }

        public static ToDoList GetToDoListByVip(string name)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            toDoList.RemoveAll(x => x.Description.EndsWith("!") != true);

            return new ToDoList() { Success = true, Count = toDoList.Count, Name = toDoList.First().Name, Items = toDoList };
        }

        public static void UpdateToDoItemWithEstimate(int id, int estimationtime)
        {
            var dbSession = new DataAccessLayer();

            var toDoItem = dbSession.GetToDoById(id);

            toDoItem.EstimationTime = estimationtime;

            dbSession.UpdateToDo(toDoItem);
        }

        public static TotalEstimation GetTotalEstimation(string name, bool includeFinnished)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            if (!includeFinnished)
                toDoList.RemoveAll(x => x.Finnished);

            var totalEstimation = toDoList.Select(x => x.EstimationTime).Sum();

            return new TotalEstimation() { Success = true, TotalMinutes = totalEstimation, TimeCompleted = DateTime.Now.AddMinutes(totalEstimation) };
        }


        public static ToDoList GetToDoListOrderedAscendingByDeadLine(string name)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            var toDoListOrderedAscendingByDeadLine = toDoList.OrderBy(o => o.DeadLine).ToList();

            return new ToDoList() { Name = toDoListOrderedAscendingByDeadLine.First().Name, Count = toDoListOrderedAscendingByDeadLine.Count, Items = toDoListOrderedAscendingByDeadLine, Success = true };
        }
    }

}


