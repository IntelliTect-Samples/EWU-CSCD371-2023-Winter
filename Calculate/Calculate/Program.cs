namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; } = input => Console.WriteLine(input);
    public Action<string> Write { get; init; } = input => Console.Write(input);
    public Func<string?> ReadLine { get; init; } = () => Console.ReadLine();    

    static void Main()
    {
        Program program = new();
        Calculator calculator = new();
        bool exit = false;

        program.WriteLine("SINGLE OPERATION CALCULATOR\n");

        while (!exit)
        {
            program.Write("Enter expression, or q to quit: ");
            string? input = program.ReadLine();
            bool isParsed = calculator.TryCalculate(input!, out int result);
            if (isParsed)
            {
                program.WriteLine($"The anwser is: {result}");
            }
            else if (input!.Equals("q"))
            {
                exit = true;
            }
            else
            {
                program.WriteLine("Incorrect input, please try again");
            }
        }
    }
}
