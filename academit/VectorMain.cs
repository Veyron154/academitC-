using System;

namespace Academit.Vector
{
    internal class Class1
    {
        public static void Main(string[] args)
        {
            var d1 = new double[3];
            d1[0] = 1;
            d1[1] = 2;
            d1[2] = 3;

            var vector = new Vector(4, d1);
            var vector2 = new Vector(5, d1);

            Console.WriteLine(vector.Equals(d1));
            Console.WriteLine(vector.Addition(vector2).ToString());
            Console.WriteLine(vector.GetLength());
            Console.WriteLine(vector.GetSize());
            Console.WriteLine(vector.GetVectorComponent(1));
            Console.WriteLine(vector.MultiplyByScalar(10));
            Console.WriteLine(vector.Turn());
            Console.ReadKey();
        }
    }
}
