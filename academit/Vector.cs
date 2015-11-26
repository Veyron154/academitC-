using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace academit
{
    class Vector
    {
        private double[] vectorComponents;
        
        public Vector (int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Размерность вектора должна быть больше нуля");
            }
            this.vectorComponents = new double[size];
        }

        public Vector (Vector copiedVector)
        {
            this.vectorComponents = new double[copiedVector.vectorComponents.Length];
            for (int i = 0; i < this.vectorComponents.Length; ++i)
            {
                this.vectorComponents[i] = copiedVector.vectorComponents[i];
            }
        }

        public Vector (int size, double[] vectorComponents)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Размерность вектора должна быть больше нуля");
            }
            this.vectorComponents = new Double[size];
            if (vectorComponents.Length < size)
            {
                for (int i = 0; i < vectorComponents.Length; ++i)
                {
                    this.vectorComponents[i] = vectorComponents[i];
                }
            }
            else
            {
                for (int i = 0; i < size; ++i)
                {
                    this.vectorComponents[i] = vectorComponents[i];
                }
            }
        }

        public Vector (double[] vectorComponents)
        {
            this.vectorComponents = vectorComponents;
        }

        override
        public string ToString ()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{ ");
            foreach (double d in this.vectorComponents)
            {
                builder.Append(d)
                    .Append(", ");
            }
            builder.Append("}");
            return builder.Remove(builder.Length - 3, 1).ToString();
        }

        public static Vector Addition(Vector vector1, Vector vector2)
        {
            Vector auxiliaryVector1 = vector1.vectorComponents.Length > vector2.vectorComponents.Length ?
                new Vector(vector1) : new Vector(vector2);
            Vector auxiliaryVector2 = vector1.vectorComponents.Length > vector2.vectorComponents.Length ?
                new Vector(ExtensionVector(vector2.vectorComponents, vector1.vectorComponents.Length)) :
                new Vector(ExtensionVector(vector1.vectorComponents, vector2.vectorComponents.Length));
            for (int i = 0; i < auxiliaryVector1.vectorComponents.Length; ++i)
            {
                auxiliaryVector1.vectorComponents[i] += auxiliaryVector2.vectorComponents[i];
            }
            return auxiliaryVector1;
        }

        private static double[] ExtensionVector(double[] vectorComponents, int size)
        {
            double[] auxiliaryArray = new double[size];
            for (int i = 0; i < vectorComponents.Length; ++i)
            {
                auxiliaryArray[i] = vectorComponents[i];
            }
            return auxiliaryArray;
        }

        public static Vector Subtraction(Vector vector1, Vector vector2)
        {
            Vector auxiliaryVector1 = vector1.vectorComponents.Length > vector2.vectorComponents.Length ?
                new Vector(vector1) :
                new Vector(ExtensionVector(vector1.vectorComponents, vector2.vectorComponents.Length));
            Vector auxiliaryVector2 = vector1.vectorComponents.Length > vector2.vectorComponents.Length ?
                new Vector(ExtensionVector(vector2.vectorComponents, vector1.vectorComponents.Length)) :
                new Vector(vector2) ;
            for (int i = 0; i < auxiliaryVector1.vectorComponents.Length; ++i)
            {
                auxiliaryVector1.vectorComponents[i] -= auxiliaryVector2.vectorComponents[i];
            }
            return auxiliaryVector1;
        }

        public static double ScalarMultiply(Vector vector1, Vector vector2)
        {
            double sum = 0;
            int minLength = Math.Min(vector1.vectorComponents.Length, vector2.vectorComponents.Length);
            for (int i = 0; i < minLength; ++i)
            {
                sum += vector1.vectorComponents[i] * vector2.vectorComponents[i];
            }
            return sum;
        }

        public int GetSize()
        {
            return this.vectorComponents.Length;
        }

        public Vector Addition(Vector addedVector)
        {
            this.vectorComponents = Addition(this, addedVector).vectorComponents;
            return this;
        }

        public Vector Subtraction(Vector deductibleVector)
        {
            this.vectorComponents = Subtraction(this, deductibleVector).vectorComponents;
            return this;
        }

        public Vector MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < this.vectorComponents.Length; ++i)
            {
                this.vectorComponents[i] *= scalar;
            }
            return this;
        }

        public Vector Turn()
        {
            const int TURN_COEFFICIENT = -1;
            return this.MultiplyByScalar(TURN_COEFFICIENT); 
        }

        public double GetLength()
        {
            double sumOfSqares = 0;
            for (int i = 0; i < this.vectorComponents.Length; ++i)
            {
                sumOfSqares += Math.Pow(this.vectorComponents[i], 2);
            }
            return Math.Sqrt(sumOfSqares);
        }

        public void SetVectorComponent(int indexOfComponent, double valueOfComponent)
        {
            this.vectorComponents[indexOfComponent] = valueOfComponent;
        }

        public double GetVectorComponent(int indexOfComponent)
        {
            return this.vectorComponents[indexOfComponent];
        }

        override
        public bool Equals(object comparedObject)
        {
            if (this == comparedObject)
            {
                return true;
            }
            if (comparedObject == null)
            {
                return false;
            }
            if (this.GetType() != comparedObject.GetType())
            {
                return false;
            }
            Vector comparedVector = comparedObject as Vector;
            if (this.vectorComponents.Length != comparedVector.vectorComponents.Length)
            {
                return false;
            }
            for (int i = 0; i < this.vectorComponents.Length; ++i)
            {
                if (!UserFunctions.IsEquals(this.vectorComponents[i], comparedVector.vectorComponents[i]))
                {
                    return false;
                }
            }
           
            return true;
        }

        override
        public int GetHashCode()
        {
            const int PRIME = 31;
            int result = 1;
            result = result * PRIME + this.vectorComponents.Length;
            for (int i = 0; i < this.vectorComponents.Length; ++i)
            {
                result = result * PRIME + (int)(this.vectorComponents[i] / UserFunctions.EPSILON);
            }
            return result;
        }
    }
}
