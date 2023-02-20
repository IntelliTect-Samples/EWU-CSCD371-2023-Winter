using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            Program prog = new()
            {
                WriteLine = Console.WriteLine,
                ReadLine = Console.ReadLine!
            };
            prog.WriteLine("Please enter an equation to be solved.");
            string equation = prog.ReadLine!();
            Calculator calc = new();
            float result;
            bool calculatedSuccessfully = true;
            calculatedSuccessfully = calc.TryCalculate(equation, out result);
            if (calculatedSuccessfully)
            {
                prog.WriteLine($"The answer to the equation is: {result}");
            }
            else 
            {
                prog.WriteLine!("The equation inputed was not in the right format.");
            }
        }
        public Action<string>? WriteLine { get; init; }
        public Func<string>? ReadLine { get; init; }
        public Program() 
        {
            
        }
    }
}
