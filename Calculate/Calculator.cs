public class Calculator
{
    private readonly Dictionary<string, Func<int, int, int>> _operations;

    public Calculator()
    {
        _operations = new Dictionary<string, Func<int, int, int>>
        {
            { "+", (x, y) => x + y },
            { "-", (x, y) => x - y },
            { "*", (x, y) => x * y },
            { "/", (x, y) => x / y }
        };
    }

    public bool TryCalculate(string input, out int result)
    {
        result = 0;

        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        string[] parts = input.Split(' ');
        if (parts.Length != 3)
        {
            return false;
        }

        if (!int.TryParse(parts[0], out int leftOperand) || !int.TryParse(parts[2], out int rightOperand))
        {
            return false;
        }

        if (!_operations.TryGetValue(parts[1], out Func<int, int, int> operation))
        {
            return false;
        }

        try
        {
            result = operation(leftOperand, rightOperand);
            return true;
        }
        catch (DivideByZeroException)
        {
            return false;
        }
    }
}
