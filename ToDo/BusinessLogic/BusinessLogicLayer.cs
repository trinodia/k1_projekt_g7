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
            dbSession.DeleteToDoList(id);
        }

        public static void AddToDoList(string name)
        {
            if (name == null)
                throw new NullReferenceException("The lists name may not be null.");

            if (name.Length < 6)
                throw new ArgumentException("The name of the list most be at least 6 chars.");

            var dbSession = new DataAccessLayer();

            if (dbSession.GetToDoListByName(name).Count > 0)
                throw new ArgumentException("A list with this name already exists and the name of a list most be unique.");

            var newToDo = new ToDo()
            {
                Name = name,
                Description = "",
                Finnished = false,
                CreatedDate = DateTime.Now,
                DeadLine = DateTime.Now,
                EstimationTime = -1
            };

            dbSession.AddToDo(newToDo);
        }

        public static void AddToDoEntry(string name,string description, DateTime deadline, int estimationtime)
        {
            if (name == null && description == null && deadline == null)
                throw new NullReferenceException("The Entry must be complete.");

            if (estimationtime <=  0)
                throw new ArgumentException("The Estimated time must be positive ");

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
    }


    }


