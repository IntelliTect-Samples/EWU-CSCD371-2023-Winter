namespace Calculate;
public class Program
{
    public Action<string> WriteLine { get; init; }
    public Func<string> ReadLine { get; init; }

    public Program()
    {
        WriteLine = Console.WriteLine;
        ReadLine = Console.ReadLine;
    }
    static void Main() 
    {
        Program mainProg = new();
        Calculator calc = new();
        bool exit = false;
        mainProg.WriteLine("Welcome to this really awful calculator app-thing. Currently only single-operation " +
                "calculations are supported, using +, -, * or /. Typing quit will exit the program." +
                "\nPlease enter an equation or exit command: ");

        do
        {
            string input = mainProg.ReadLine();
            if (input.Equals("quit"))
            {
                exit = true;
                mainProg.WriteLine("Closing application...");
            } else if (Calculator.TryCalculate(input, out double res))
            {
                mainProg.WriteLine($"Calculation successful for input: {input}\nResult is: {res}");
                mainProg.WriteLine("Please enter new equation or exit command: ");
            }
            else
            {
                mainProg.WriteLine("Invalid input. Please try again: ");
            }
        } while (!exit);
    }
}