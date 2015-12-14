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

        public static void AddToDoList(string name)
        {
            try
            {
                if (name.Length < 6)
                {
                    throw new ArgumentException("Namn på listan måste vara minst 6 tecken");
                }
                else
                {
                    var dbSession = new DataAccessLayer();

                    var currentLists = dbSession.GetToDoListByName(name);
                    if (currentLists.Count > 0)
                    {
                        throw new ArgumentException("Namnet på listan måste vara unikt");
                    }
                    else
                    {
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
