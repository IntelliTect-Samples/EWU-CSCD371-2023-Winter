namespace Calculate
{
    public class Program
    {
        public Func<string?> ReadLine { get; init; } = System.Console.ReadLine;

        public Action<string?> WriteLine { get; init; } = System.Console.WriteLine;

        public Calculator Calc { get; }

        public Program()
        {
            Calc = new Calculator();
        }

        static void Main(string[] args)
        {
            Program program = new();
            bool exit = false;
            do
            {
                program.WriteLine("Enter a mathematical expression (addition, subtraction, multiplicaiton, division, or \"exit\" to exit");
                string? input = program.ReadLine();
                if (input is null) { program.WriteLine("Invalid input, please try again."); }
                else if (input.ToLower().Equals("exit")) { exit = true; }
                else
                {
                    if (program.Calc.TryCalculate(input, out int result))
                    {
                        program.WriteLine($"The answer is {result}");
                    }
                    else { program.WriteLine("Invalid input, please try again."); }
                }
            } while (!exit);
        }
    }
}