using System;

class Program
{
    static void Main()
    {
        var calculator = new Calculator();
        var program = new Program();
        program.SetUpInput(Console.WriteLine, Console.ReadLine);
        program.Run(calculator);
    }

    public Action<string> WriteLine { get; set; }
    public Func<string> ReadLine { get; set; }
    public void SetUpInput(Action<string> writeLine, Func<string> readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }

    public void Run(Calculator calculator)
    {
        while (true)
        {
            WriteLine("Enter function in form x + y");
            string input = ReadLine();
            if (string.IsNullOrWhiteSpace(input)) break;

            if (calculator.TryCalculate(input, out int result))
            {
                WriteLine(result.ToString());
            }
            else
            {
                WriteLine("Invalid input");
            }
        }
    }
}
