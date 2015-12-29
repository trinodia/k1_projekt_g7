using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.RequestObjects
{
    public class UpdateToDoWithEstimate
    {
        public int id { get; set; }
        public int estimationtime { get; set; }
    }
}
