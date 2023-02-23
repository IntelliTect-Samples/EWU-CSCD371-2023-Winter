namespace Calculate;

public class Calculator
{
    public IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations { get; }
    public Calculator()
    {
        MathematicalOperations = new Dictionary<char, Func<int, int, double>>()
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
        return (double) paramOne / paramTwo;
    }

    public static bool TryCalculate(string calculation, out double result)
    {
        bool TF = false;
        result = default;
        Calculator calc = new();

        string[] ints = calculation.Split(' ');
        if (ints.Length != 3)
        {
            return TF;
        }
        if (int.TryParse(ints[0], out int firstInt) && char.TryParse(ints[1], out char op) && calc.MathematicalOperations.ContainsKey(op) && int.TryParse(ints[2], out int secondInt))
        {
            TF = true;
            Func<int, int, double> operation = calc.MathematicalOperations[op];
            result = operation(firstInt, secondInt);
        }

        return TF;
    }
}
