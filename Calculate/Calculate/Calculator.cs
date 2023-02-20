using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Calculator
    {
        public Calculator() 
        {
            MathematicalOperations = new Dictionary<char, Func<float, float, float>>();
        }
        public IReadOnlyDictionary<char,Func<float,float,float>>? MathematicalOperations { get; }
        public static float Add(float leftOperand, float rightOperand) 
        {
            return leftOperand + rightOperand;
        }
        public static float Subtract(float leftOperand, float rightOperand)
        {
            return leftOperand - rightOperand;
        }
        public static float Multiply(float leftOperand, float rightOperand)
        {
            return leftOperand * rightOperand;
        }
        public static float Divide(float leftOperand, float rightOperand)
        {
            return leftOperand / rightOperand;
        }
    }
}
