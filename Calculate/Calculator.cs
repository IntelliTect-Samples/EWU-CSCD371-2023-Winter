namespace Calculate;

public class Calculator
{
    public IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperators { get; }
    public Calculator()
    {
        MathematicalOperators = new Dictionary<char, Func<int, int, double>>()
        {
            {'/', Divide},
            {'*', Multiply},
            {'-', Subtract},
            {'+', Add}
        };
    }

    public static double Add(int paramOne, int paramTwo)
    {
        return paramOne + paramTwo;
    }

    public static double Subtract(int paramOne, int paramTwo)
    {
        return paramOne - paramTwo;
    }

    public static double Multiply(int paramOne, int paramTwo)
    {
        return paramOne * paramTwo;
    }

    public static double Divide(int paramOne, int paramTwo)
    {
        return ((double)paramOne / paramTwo);
    }

    public static bool TryCalculate(string calculation, out double result)
    {
        bool TF = false;
        result = 0;
        Calculator calc = new();
        char[] validOperators =
        {
            '+', '-', '*', '/'
        };

        string[] ints = calculation.Split(' ');
        if (ints.Length < 3)
        {
            return TF;
        }
        int firstInt, secondInt;
        char op;
        if(int.TryParse(ints[0], out firstInt) && char.TryParse(ints[1], out op) && validOperators.Contains(op) && int.TryParse(ints[2], out secondInt))
        {
            TF = true;
            Func<int, int, double> operation = calc.MathematicalOperators[op];
            result = operation(firstInt, secondInt);
        }

        return TF;
    }
}
