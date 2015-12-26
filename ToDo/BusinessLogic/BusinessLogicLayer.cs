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
            //TODO: Add exception handling;

            var dbSession = new DataAccessLayer();

            var toDoItem = dbSession.GetToDoById(id);

            return toDoItem; //Rewrite when method only returns a ToDoItem instead of ToDoList;
        }

        public static List<ToDo> GetToDoListByName(string name)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            if (toDoList == null)
                throw new NullReferenceException("A list with the given name could not be retrieved.");

            if (!toDoList.Any())
                throw new ArgumentException("A list with the given name could not be found.");

            return toDoList;
        }

        public static void DeleteToDoItemById(int id)
        {
            var dbSession = new DataAccessLayer();

            if (id == 0)
                throw new ArgumentException("ID can't be 0.");

            if (id < 0)
                throw new ArgumentException("ID can't be negative.");

            if (dbSession.GetToDoById(id) == null)
                throw new ArgumentException("The specified ID could not be found.");

            dbSession.DeleteToDo(id);
        }

        public static void FinishToDoItem(int id)
        {
            var dbSession = new DataAccessLayer();

            if (id == 0)
                throw new ArgumentException("ID can't be 0.");

            if (id < 0)
                throw new ArgumentException("ID can't be negative.");

            if (dbSession.GetToDoById(id) == null)
                throw new ArgumentException("The specified ID could not be found.");

            var toDoItemToFinnish = dbSession.GetToDoById(id);

            if (!toDoItemToFinnish.Finnished)
                toDoItemToFinnish.Finnished = true;
            
            dbSession.UpdateToDo(toDoItemToFinnish);
        }

        public static void UnFinishToDoItem(int id)
        {
            var dbSession = new DataAccessLayer();

            if (id == 0)
                throw new ArgumentException("ID can't be 0.");

            if (id < 0)
                throw new ArgumentException("ID can't be negative.");

            if (dbSession.GetToDoById(id) == null)
                throw new ArgumentException("The specified ID could not be found.");

            var toDoItemToFinnish = dbSession.GetToDoById(id);

            if (toDoItemToFinnish.Finnished)
                toDoItemToFinnish.Finnished = false;

            dbSession.UpdateToDo(toDoItemToFinnish);
        }

        public static void SetDeadLineToDoItem(int id, DateTime newDeadLine)
        {
            var dbSession = new DataAccessLayer();

            if (id == 0)
                throw new ArgumentException("ID can't be 0.");

            if (id < 0)
                throw new ArgumentException("ID can't be negative.");

            if (dbSession.GetToDoById(id) == null)
                throw new ArgumentException("The specified ID could not be found.");

            var toDoItemToUpdateDeadLineFor = dbSession.GetToDoById(id);

            toDoItemToUpdateDeadLineFor.DeadLine = newDeadLine;

            dbSession.UpdateToDo(toDoItemToUpdateDeadLineFor);
        }

        public static void AddToDoList(string name, string description, DateTime? deadline, int estimationtime = -1)
        {
            if (name == null)
                throw new ArgumentNullException("The lists name may not be null.");

            if (description == null)
                throw new ArgumentNullException("The lists description may not be null.");

            if (name.Length < 6)
                throw new ArgumentException("The name of the list most be at least 6 chars.");

            var dbSession = new DataAccessLayer();

            // If no deadline is provided, set a default deadline
            deadline = deadline ?? new DateTime(1800, 1, 1, 0, 0, 0);

            if (dbSession.GetToDoListByName(name).Count > 0)
                throw new ArgumentException("A list with this name already exists and the name of a list most be unique.");

            var newToDo = new ToDo()
            {
                Name = name,
                Description = description,
                Finnished = false,
                CreatedDate = DateTime.Now,
                DeadLine = (DateTime)deadline,
                EstimationTime = estimationtime
            };

            dbSession.AddToDo(newToDo);
        }

        public static void AddToDoEntry(string name,string description, DateTime deadline, int estimationtime)
        {
            if (name == null && description == null && deadline == null) //TODO: Should be logic OR and one error message per incorrect param?
                throw new NullReferenceException("The Entry must be complete.");

            if (estimationtime <=  0)
                throw new ArgumentException("The Estimated time must be positive.");

            var dbSession = new DataAccessLayer();

            if (dbSession.GetToDoListByName(name).Count < 1 )
                throw new ArgumentException("A list must be created first.");
            //if (dbSession.GetToDoListByName(name).First   // Ersätta den första tomma ??

            var newToDo = new ToDo()
            {
                Name = name,
                Description = description,
                Finnished = false,
                CreatedDate = DateTime.Now,
                DeadLine = deadline,
                EstimationTime = estimationtime
            };

            dbSession.AddToDo(newToDo);
        }

        public static List<ToDo> GetToDoListByDone(string name)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name);

            if (toDoList == null)
                throw new NullReferenceException("A list with the given name could not be retrieved.");

            if (!toDoList.Any())
                throw new ArgumentException("A list with the given name could not be found.");


             
            toDoList.RemoveAll(x => x.Finnished == false);

            return toDoList;
        }

        public static int GetNumberOfToDoItemsInList(string name, bool finnished)
        {
            var dbSession = new DataAccessLayer();

            if (name == null)
                throw new ArgumentNullException("Name may not be null.");

            var toDoList = dbSession.GetToDoListByName(name);

            if (toDoList == null)
                throw new NullReferenceException("A list with the given name could not be retrieved.");

            // return how many items that was removed
            return toDoList.RemoveAll(x => x.Finnished == finnished);
        }

        public static void UpdateToDoItem(ToDo todoitem)
        {
            //TODO: Add exception handling;

            var dbSession = new DataAccessLayer();

            dbSession.UpdateToDo(todoitem);
            
            //return Errorcode of shit if needed; 
        }

        public static List<ToDo> GetToDoListByVip(string name)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name); // Just getting by Name, or does we want ALL Lists? 

            if (toDoList == null)
                throw new NullReferenceException("A list with the given name could not be retrieved.");

            if (!toDoList.Any())
                throw new ArgumentException("A list with the given name could not be found.");

            //toDoList.RemoveAll(x => x.Finnished == false);
             
            toDoList.RemoveAll(x => x.Description.EndsWith("!") != true);
            return toDoList;
        }

        public static List<ToDo> GetToDoListOrderedAscendingByDeadLine(string name)
        {
            var dbSession = new DataAccessLayer();

            var toDoList = dbSession.GetToDoListByName(name); // Just getting by Name, or does we want ALL Lists? 

            if (toDoList == null)
                throw new NullReferenceException("A list with the given name could not be retrieved.");

            if (!toDoList.Any())
                throw new ArgumentException("A list with the given name could not be found.");

            var toDoListOrderedAscendingByDeadLine = toDoList.OrderBy(o => o.DeadLine).ToList();

            return toDoListOrderedAscendingByDeadLine;
        }
    }

}


