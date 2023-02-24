namespace Calculate
{
    public class Calculator
    {
        public IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations { get; } = new Dictionary<char, Func<int, int, double>>()
        {
            { '+', Add },
            { '-', Subtract },
            { '*', Multiply },
            { '/', Divide }
        };

        public static double Add(int x, int y) { return x + y; }
        public static double Subtract(int x, int y) { return x - y; }
        public static double Multiply(int x, int y) { return x * y; }
        public static double Divide(int x, int y) 
        {
            return (double) x / (double) y;
        }

        public bool TryCalculate(string expression, out double result)
        {
            double value = 0;
            if (expression.Split(" ") is [string firstOperand, [char op], string secondOperand])
            {
                if (!Int32.TryParse(firstOperand, out int firstNumber) ||
                    !Int32.TryParse(secondOperand, out int secondNumber) ||
                    !MathematicalOperations.TryGetValue(op, out Func<int, int, double>? operation))
                {
                    result = 0;
                    return false;
                }
                value = operation(firstNumber, secondNumber);
                if(double.IsInfinity(value))
                {
                    result = 0;
                    return false;
                }
            }
            else
            {
                result = 0;
                return false;
            }
            result = value;
            return true;
        }
    }
}