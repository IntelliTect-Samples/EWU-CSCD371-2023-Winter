namespace Calculate;

public class Program
{
    public delegate string ReadDelegator();

    public delegate void WriteDelegator(string message);

    public Program(WriteDelegator writeLine, ReadDelegator readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }

    public Program()
    {
        WriteLine = Console.WriteLine;
        ReadLine = Console.ReadLine!;
    }

    public WriteDelegator WriteLine { get; }
    public ReadDelegator ReadLine { get; }

    public Calculate GetCalculator() => new(WriteLine, ReadLine);

    public static void Main()
    {
        Program program = new();
        Calculate calculate = program.GetCalculator();
        while (true) calculate.TryCalculate();
    }
}