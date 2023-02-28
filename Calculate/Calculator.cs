using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Calculator
    {
        public static Func<int, int, int> Add => (x, y) => x + y;
        public static Func<int, int, int> Subtract => (x, y) => x - y;
        public static Func<int, int, int> Multiply => (x, y) => x * y;
        public static Func<int, int, int> Divide => (x, y) =>
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Can not divide by zero");
            }
            else
            { return x / y; }
        };

        public static IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; } = new Dictionary<char, Func<int, int, int>>()
    {
        {'+', Add },
        {'-', Subtract },
        {'*', Multiply },
        {'/', Divide },
    };

        public static bool TryCalculate(string calculation, out int result)
        {
            result = 0;
            int operand1;
            int operand2;
            char operator1;

            string[] input = calculation.Split(' ');

            if (input.Length != 3)
            {
                return false;
            }
            else if (!int.TryParse(input[0], out operand1) || !char.TryParse(input[1], out operator1)
                || !int.TryParse(input[2], out operand2))
            {
                return false;
            }
            else if (!Calculator.MathematicalOperations.TryGetValue(operator1, out var operation))
            {
                return false;
            }
            else
            {
                result = operation(operand1, operand2);
                return true;
            }

        }
    }
}
