using System.Collections.Generic;
using DataModel;
using DataAccess;
using System;

namespace BusinessLogic
{
    public class BusinessLogicLayer
    {
        public static List<ToDo> GetToDoListByName(string name)
        {
            var dbSession = new DataAccessLayer();
            var toDoList = dbSession.GetToDoListByName(name);
            return toDoList;
        }

        public static string AddToDo(string name, string description, bool finnished, DateTime createdDate, DateTime deadLine, int estimationTime)
        {
            string error = "";
            try
            {
                if (name.Length < 6)
                {
                    error = "Namn på listan måste vara minst 6 tecken";
                }
                else
                {


                    var dbSession = new DataAccessLayer();

                    var currentLists = dbSession.GetToDoListByName(name);
                    if (currentLists.Count > 0)
                    {
                        error = "Namnet på todolistan måste vara unikt.";
                    }
                    else
                    {
                        var newToDo = new ToDo()
                        {
                            Name = name,
                            Description = description,
                            Finnished = finnished,
                            CreatedDate = createdDate,
                            DeadLine = deadLine,
                            EstimationTime = estimationTime
                        };

                        dbSession.AddToDo(newToDo);
                    }
                }
            }
            catch
            {
                error = "Något gick fel, försök igen.";
            }
            return error;

        }
    }
}
