using System.Collections.Generic;
using DataModel;
using DataAccess;
using System;
using System.Linq;

namespace BusinessLogic
{
    public class BusinessLogicLayer
    {
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

        public static void DeleteToDoItem(int id)
        {
            //TODO:Add error handling
            var dbSession = new DataAccessLayer();
            dbSession.DeleteToDo(id);
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
    }
}
