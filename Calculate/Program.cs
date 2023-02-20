using Calculate;
namespace Calculate;
using System;


class Program
{
    static void Main()
    {
        var calculator = new Calculator();

        while (true)
        {
            Console.WriteLine("Enter function in form x + y");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) break;

            if (calculator.TryCalculate(input, out int result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
 
    public  Action<string> WriteLine { get; init; } = Console.WriteLine;
    public  Func<string> ReadLine { get; init; } = Console.ReadLine;
}
