using System;

namespace Academit.Vector
{
    internal static class UserFunctions
    {
        public static readonly double Epsilon = 1e-4;

        public static bool IsEquals(double number1, double number2)
        {
            return Math.Abs(number1 - number2) < Epsilon;
        }
    }
}
