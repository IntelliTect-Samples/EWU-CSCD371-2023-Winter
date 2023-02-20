﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
     public class Calculator
    {
        private static readonly IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations = new Dictionary<char, Func<int, int, int>>
        {
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiply,
            ['/'] = Divide
        };

        // Use top-level statements for static Add, Subtract, Multiply, and Divide methods
        private static int Add(int x, int y) => x + y;
        private static int Subtract(int x, int y) => x - y;
        private static int Multiply(int x, int y) => x * y;
        private static int Divide(int x, int y) => y != 0 ? x / y : throw new DivideByZeroException();

        public bool TryCalculate(string input, out int result)
        {
            // Parse the input using top-level statements
            string[] parts = input.Split(' ');
            if (parts.Length != 3 || !int.TryParse(parts[0], out int x) || !int.TryParse(parts[2], out int y))
            {
                result = 0;
                return false;
            }

            // Use pattern matching and indexing with MathematicalOperations using top-level statements
            if (MathematicalOperations.TryGetValue(parts[1][0], out var op))
            {
                result = op(x, y);
                return true;
            }

            result = 0;
            return false;
        }
    }
}

