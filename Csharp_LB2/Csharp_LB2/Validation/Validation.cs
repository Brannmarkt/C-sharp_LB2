using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_LB2.Validation
{
    class Validation
    {
        public int Validate(int value)
        {
            if (value < 0)
                return 0;
            else
                return 1;
        }
    }
}
