using System.Linq.Expressions;

namespace Calculate
{
    public class Calculator
    {
        private static readonly Func<int, int, int> Add = (left, right) => left + right;
        private static readonly Func<int, int, int> Subtract = (left, right) => left - right;
        private static readonly Func<int, int, int> Multiply  = (left, right) => left * right;
        private static readonly Func<int, int, int> Divide  = (left, right) => 
        right.Equals(0) ? left / right : throw new ArgumentException("Cannot Divide by 0");

        public IReadOnlyDictionary<char, Func<int, int, int>> MathmaticalOperations = new Dictionary<char, Func<int, int, int>>
        {
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiply,
            ['/'] = Divide,
        };

        public bool TryCalculate(string expression, out int result)
        {
            string[] expressionArray = expression.Split(" ");

            if (!expressionArray.Length.Equals(3))
            {
                result = 0;
                return false;
            }

            if (int.TryParse(expressionArray[0], out int left) && 
                char.TryParse(expressionArray[1], out char op) && 
                int.TryParse(expressionArray[2], out int right))
            {
                result = MathmaticalOperations[op](left, right);
                return true;
            }
            else
            {
                result = 0;
                return false;
            }
        }
    }
}
