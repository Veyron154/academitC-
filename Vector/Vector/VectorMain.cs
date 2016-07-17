using System;

namespace Academit.Vector
{
    internal class Class1
    {
        public static void Main(string[] args)
        {
            double[] d1 = {1, 2, 3};
            double[] d2 = {1, 2, 3};

            var vector = new Vector(3, d1);
            var vector2 = new Vector(3, d2);

            Console.WriteLine(vector.Equals(vector2));
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
