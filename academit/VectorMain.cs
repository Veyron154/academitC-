using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace academit
{
    class Class1
    {
        public static void Main (string[] args)
        {
            double[] d1 = new double[3];
            d1[0] = 1;
            d1[1] = 2;
            d1[2] = 3;

            Vector vector = new Vector(4, d1);
            Vector vector2 = new Vector(5, d1);

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
