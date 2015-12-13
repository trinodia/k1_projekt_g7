using System.Collections.Generic;
using DataModel;
using DataAccess;

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
    }
}
