using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Calculator
    {
        public IReadOnlyDictionary<char, Func<float, float, float>>? MathematicalOperations 
            { get; } = new Dictionary<char, Func<float, float, float>>
            {
                {'+', Add },
                {'-', Subtract },
                {'*', Multiply },
                {'/', Divide }
            };
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
                float LeftOperand; 
                float RightOperand; 
                try 
                {
                    LeftOperand = float.Parse(leftOperand);
                    RightOperand = float.Parse(rightOperand);
                } catch(FormatException ex) 
                {
                    result = 0;
                    return false;
                }
                switch (operatr) 
                {
                    case ("+"):
                        result = MathematicalOperations!.GetValueOrDefault('+')!.Invoke(LeftOperand, RightOperand);
                        return true;
                    case ("-"):
                        result = MathematicalOperations!.GetValueOrDefault('-')!.Invoke(LeftOperand, RightOperand);
                        return true;
                    case ("*"):
                        result = MathematicalOperations!.GetValueOrDefault('*')!.Invoke(LeftOperand, RightOperand);
                        return true;
                    case ("/"):
                        result = MathematicalOperations!.GetValueOrDefault('/')!.Invoke(LeftOperand, RightOperand);
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
