using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Model.Enums
{
    public class Constants
    {
        public enum Days
        {
            Monday = 1,
            Thuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public enum Services
        {
            Midday=1,
            Evening
        }
    }
}
