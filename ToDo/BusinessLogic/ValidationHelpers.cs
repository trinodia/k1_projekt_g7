using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ValidationHelpers
    {

        public static bool ValidateID(int id)
        {

            return true;
        }

        public static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Name may not be null, empty or whitespace.");

            return true;
        }

    }
}
