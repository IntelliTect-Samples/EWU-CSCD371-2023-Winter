namespace Calculate;

public class Calculate
{
    public Calculate(Program.WriteDelegator writeLine, Program.ReadDelegator readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }

    private static IReadOnlyDictionary<char, OperationDelegator> MathematicalOperations =>
        new Dictionary<char, OperationDelegator>
        {
            { '+', Add },
            { '-', Subtract },
            { '*', Multiple },
            { '/', Divide }
        };

    private Program.WriteDelegator WriteLine { get; }
    private Program.ReadDelegator ReadLine { get; }

    private static int Add(int a, int b) => a + b;
    private static int Subtract(int a, int b) => a - b;
    private static int Multiple(int a, int b) => a * b;
    private static int Divide(int a, int b) => a / b;


    public bool TryCalculate()
    {
        string calculation = ReadLine();
        string[] parts = calculation.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (
            parts.Length != 3 ||
            !int.TryParse(parts[0], out int a) ||
            !char.TryParse(parts[1], out char op) ||
            !MathematicalOperations.ContainsKey(op) ||
            !int.TryParse(parts[2], out int b)
        ) return false;

        WriteLine(MathematicalOperations[op](a, b).ToString());

        return true;
    }

    private delegate int OperationDelegator(int a, int b);
}