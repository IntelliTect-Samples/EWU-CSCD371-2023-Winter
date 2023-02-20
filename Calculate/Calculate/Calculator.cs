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
        public bool TryCalculate(string equation, out float result) 
        {
            if (equation.Split(" ") is [string { Length: > 0 } leftOperand, 
                string { Length: > 0} operatr, string { Length: > 0} rightOperand]) 
            {
                float LeftOperand = float.Parse(leftOperand);
                float RightOperand = float.Parse(rightOperand);
                switch (operatr) 
                {
                    case("+"):
                        result = Add(LeftOperand, RightOperand);
                        return true;
                    case ("-"):
                        result = Subtract(LeftOperand, RightOperand);
                        return true;
                    case ("*"):
                        result = Multiply(LeftOperand, RightOperand);
                        return true;
                    case ("/"):
                        result = Divide(LeftOperand, RightOperand);
                        return true;
                    default:
                        result = 0;
                        return false;
                }
            }
            result = 0;
            return false;
        }
    }
}
