using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.RequestObjects
{
    public class GetTotalEstimation
    {
        public string name { get; set; }
        public bool includeFinnished { get; set; }
    }
}
