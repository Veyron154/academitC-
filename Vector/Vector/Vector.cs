using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Academit.Vector
{
    internal class Vector
    {
        private const string ExeptionText = "Размерность вектора должна быть больше нуля";
        private double[] _vectorComponents;

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(ExeptionText);
            }
            _vectorComponents = new double[size];
        }

        public Vector(Vector copiedVector)
        {
            _vectorComponents = new double[copiedVector._vectorComponents.Length];
            for (var i = 0; i < _vectorComponents.Length; ++i)
            {
                _vectorComponents[i] = copiedVector._vectorComponents[i];
            }
        }

        public Vector(int size, IReadOnlyList<double> vectorComponents)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(ExeptionText);
            }
            _vectorComponents = new double[size];
            if (vectorComponents.Count < size)
            {
                for (var i = 0; i < vectorComponents.Count; ++i)
                {
                    _vectorComponents[i] = vectorComponents[i];
                }
            }
            else
            {
                for (var i = 0; i < size; ++i)
                {
                    _vectorComponents[i] = vectorComponents[i];
                }
            }
        }

        public Vector(double[] vectorComponents)
        {
            _vectorComponents = vectorComponents;
        }

       
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{ ");
            foreach (var d in _vectorComponents)
            {
                builder.Append(d)
                    .Append(", ");
            }
            builder.Append("}");
            return builder.Remove(builder.Length - 3, 1).ToString();
        }

        public static Vector Addition(Vector vector1, Vector vector2)
        {
            var auxiliaryVector1 = vector1._vectorComponents.Length > vector2._vectorComponents.Length ?
                new Vector(vector1) : new Vector(vector2);
            var auxiliaryVector2 = vector1._vectorComponents.Length > vector2._vectorComponents.Length ?
                new Vector(ExtensionVector(vector2._vectorComponents, vector1._vectorComponents.Length)) :
                new Vector(ExtensionVector(vector1._vectorComponents, vector2._vectorComponents.Length));
            for (var i = 0; i < auxiliaryVector1._vectorComponents.Length; ++i)
            {
                auxiliaryVector1._vectorComponents[i] += auxiliaryVector2._vectorComponents[i];
            }
            return auxiliaryVector1;
        }

        private static double[] ExtensionVector(IReadOnlyList<double> vectorComponents, int size)
        {
            var auxiliaryArray = new double[size];
            for (var i = 0; i < vectorComponents.Count; ++i)
            {
                auxiliaryArray[i] = vectorComponents[i];
            }
            return auxiliaryArray;
        }

        public static Vector Subtraction(Vector vector1, Vector vector2)
        {
            var auxiliaryVector1 = vector1._vectorComponents.Length > vector2._vectorComponents.Length ?
                new Vector(vector1) :
                new Vector(ExtensionVector(vector1._vectorComponents, vector2._vectorComponents.Length));
            var auxiliaryVector2 = vector1._vectorComponents.Length > vector2._vectorComponents.Length ?
                new Vector(ExtensionVector(vector2._vectorComponents, vector1._vectorComponents.Length)) :
                new Vector(vector2);
            for (var i = 0; i < auxiliaryVector1._vectorComponents.Length; ++i)
            {
                auxiliaryVector1._vectorComponents[i] -= auxiliaryVector2._vectorComponents[i];
            }
            return auxiliaryVector1;
        }

        public static double ScalarMultiply(Vector vector1, Vector vector2)
        {
            double sum = 0;
            var minLength = Math.Min(vector1._vectorComponents.Length, vector2._vectorComponents.Length);
            for (var i = 0; i < minLength; ++i)
            {
                sum += vector1._vectorComponents[i] * vector2._vectorComponents[i];
            }
            return sum;
        }

        public int GetSize()
        {
            return _vectorComponents.Length;
        }

        public Vector Addition(Vector addedVector)
        {
            _vectorComponents = Addition(this, addedVector)._vectorComponents;
            return this;
        }

        public Vector Subtraction(Vector deductibleVector)
        {
            _vectorComponents = Subtraction(this, deductibleVector)._vectorComponents;
            return this;
        }

        public Vector MultiplyByScalar(double scalar)
        {
            for (var i = 0; i < _vectorComponents.Length; ++i)
            {
                _vectorComponents[i] *= scalar;
            }
            return this;
        }

        public Vector Turn()
        {
            const int turnCoefficient = -1;
            return MultiplyByScalar(turnCoefficient);
        }

        public double GetLength()
        {
            var sumOfSqares = _vectorComponents.Sum(t => Math.Pow(t, 2));
            return Math.Sqrt(sumOfSqares);
        }

        public void SetVectorComponent(int indexOfComponent, double valueOfComponent)
        {
            _vectorComponents[indexOfComponent] = valueOfComponent;
        }

        public double GetVectorComponent(int indexOfComponent)
        {
            return _vectorComponents[indexOfComponent];
        }

        public override bool Equals(object comparedObject)
        {
            if (this == comparedObject)
            {
                return true;
            }
            if (comparedObject == null)
            {
                return false;
            }
            if (GetType() != comparedObject.GetType())
            {
                return false;
            }
            var comparedVector = (Vector)comparedObject;
            if (_vectorComponents.Length != comparedVector._vectorComponents.Length)
            {
                return false;
            }
            return !_vectorComponents.Where((t, i) => 
            !UserFunctions.IsEquals(t, comparedVector._vectorComponents[i])).Any();      
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
        {
            const int prime = 31;
            var result = 1;
            result = result * prime + _vectorComponents.Length;
            return _vectorComponents.Aggregate(result, (current, t) => current*prime + (int) (t/UserFunctions.Epsilon));
        }
    }
}
