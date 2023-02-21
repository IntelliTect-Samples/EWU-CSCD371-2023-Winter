using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Calculator
    {

        public static Func<int, int, int> Add = (int1, int2) => int1 + int2;
        public static Func<int, int, int> Subtract = (int1, int2) => int1 - int2;
        public static Func<int, int, int> Multiply = (int1, int2) => int1 * int2;
        public static Func<int, int, int> Divide = (int1, int2) =>
        {
            return int2 == 0 ? throw new DivideByZeroException("Tried to divide by zero") : int1 / int2;
        };

        public static IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; } = new Dictionary<char, Func<int, int, int>>()
        {
            { '+', Add },
            { '-', Subtract },
            { '*', Multiply },
            { '/', Divide }

        };

        public static bool TryCalculate(string input, out int result)
        {
            bool TorF = false;
            result = 0;

            char[] validOps =
            {
                '+', '-', '*', '/'
            };
            string[] ints = input.Split(' ');
            if (ints.Length != 3)
            {
                return TorF;
            }
            if (!int.TryParse(ints[0], out int int1) || !int.TryParse(ints[2], out int int2))
            {
                return TorF;
            }
            char op = ints[1][0];
            if (ints[1].Length != 1 || !MathematicalOperations.TryGetValue(ints[1][0], out var operation))
            {
                return false;
            }

            result = operation(int1, int2);
            return true;

        }

    }
}