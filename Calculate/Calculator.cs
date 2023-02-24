using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Calculator
    {

        public static int Add(int int1, int int2) => int1 + int2;
        public static int Subtract(int int1, int int2) => int1 - int2;
        public static int Multiply(int int1, int int2) => int1 * int2;
        public static int Divide(int int1, int int2)
        {
            if (int2 == 0)
            {
                throw new DivideByZeroException("Tried to divide by zero");
            }
            return int1 / int2;
        }


        public static IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations
        { get; } =
            new Dictionary<char, Func<int, int, int>>()
            {
                { '+', Add },
                { '-', Subtract },
                { '*', Multiply },
                { '/', Divide }

            };

        public bool TryCalculate(string input, out int result)
        {
            bool isTorF = false;
            result = 0;

            Calculator calculator = new();

            string[] ints = input.Split(' ');
            if (ints.Length != 3)
            {
                return isTorF;
            }
            if (!int.TryParse(ints[0], out int int1) || !int.TryParse(ints[2], out int int2))
            {
                return isTorF;
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