using System.ComponentModel;

namespace Calculate
{
    internal class Program
    {
        // private int _WriteLine;
        // private int _ReadLine;
        private readonly Action<string> _WriteLine;
        private readonly Func<string> _ReadLine;

       public Program(Action<string> writeLine, Func<string> readline)
        {
            _WriteLine = writeLine;
            _ReadLine = readline;
        }

        public static void Main(string[] args)
        {
            Program program = new Program(Console.WriteLine, Console.ReadLine);

           // Calculator calculator = new();

            bool quit = false;

            
            while (quit == false)
            {
                Console.WriteLine("Please enter a function in the form: x operator y, or q to quit");

                string input = program._ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid");
                }
                if (Calculator.TryCalculate(input, out int result))
                {
                    program._WriteLine(result.ToString());
                }
                else if (input.Equals("q"))
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