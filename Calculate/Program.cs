using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculate
{
    public class Program
    {
        public Action<string> WriteLine { get; init; } = Console.WriteLine;
        public Func<string?> ReadLine { get; init; } = Console.ReadLine;

        public Program() { }
        static void Main(string[] args)
        {
            Program progarm = new();
            Calculator calculate = new();
            int result;
            bool correctInput = true;

            while (true)
            {
                progarm.WriteLine("Enter an equation with spaces inbetween the operands and operator(ex: '5 + 3'): ");
                string? userInput = progarm.ReadLine.Invoke();
                correctInput = Calculator.TryCalculate(userInput, out result);

                if (correctInput)
                {
                    progarm.WriteLine(result.ToString());
                }
                else
                {
                    progarm.WriteLine.Invoke("Invalid input");
                }
            }

        }

    }
}
