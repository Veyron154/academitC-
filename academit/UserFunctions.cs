using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace academit
{
    class UserFunctions
    {
        public static readonly double EPSILON = 1e-4;

        public static bool IsEquals(double number1, double number2)
        {
            return Math.Abs(number1 - number2) < EPSILON;
        }
    }
}
