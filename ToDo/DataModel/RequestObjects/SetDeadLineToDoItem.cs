using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.RequestObjects
{
    public class SetDeadLineToDoItem
    {
        public int id { get; set; }
        public DateTime newDeadLine { get; set; }
    }
}
