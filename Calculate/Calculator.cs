namespace Calculate
{
    public class Calculator
    {
        private readonly Dictionary<char, Func<int, int, int>> _MathematicalOperations = new();
        public IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get => _MathematicalOperations; }
        public static int Add(int x, int y) { return x + y; }
        public static int Subtract(int x, int y) { return x - y; }
        public static int Multiply(int x, int y) { return x * y; }
        public static int Divide(int x, int y) { return x / y; }

        public bool TryCalculate(string expression, out int result)
        {
            int value = 0;
            if (expression.Split(" ") is [string firstOperand, [char op], string secondOperand])
            {
                if (!Int32.TryParse(firstOperand, out int firstNumber) || 
                    !Int32.TryParse(secondOperand, out int secondNumber) ||
                    !MathematicalOperations.TryGetValue(op, out Func<int, int, int>? operation))
                {
                    result = 0;
                    return false;
                }
                value = operation(firstNumber, secondNumber);
            }
            else
            {
                result = 0;
                return false;
            }
            result = value;
            return true;
        }

        public Calculator()
        {
            _MathematicalOperations.Add('+', Add);
            _MathematicalOperations.Add('-', Subtract);
            _MathematicalOperations.Add('*', Multiply);
            _MathematicalOperations.Add('/', Divide);
        }
    }
}