using System.ComponentModel;

namespace Calculate
{
    internal class Program
    {

        public Action<string> WriteLine { get; init; }
        public Func<string?> ReadLine { get; init; }

        public Program()
        {
            WriteLine = Console.WriteLine;
            ReadLine = Console.ReadLine;
        }
        public Program(Action<string> writeLine, Func<string?> readLine)
        {
            WriteLine = writeLine;
            ReadLine = readLine;
        }
        public static void Main()
        {
            Program program = new(Console.WriteLine, Console.ReadLine);

            Calculator calculator = new();

            bool quit = false;


            while (!quit)
            {
                Console.WriteLine("Please enter a function in the form: x operator y, or q to quit");

                string input = program.ReadLine()?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid");
                }
                if (calculator.TryCalculate(input, out int result))
                {
                    program.WriteLine(result.ToString());
                }
                else if (input.Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    quit = true;
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }

        }
    }

}