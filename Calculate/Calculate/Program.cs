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
            Program prog = new();
            Calculator calc = new();
            float result;
            bool calculatedSuccessfully;

            prog.WriteLine("Please enter an equation to be solved.");
            string equation = prog.ReadLine!();
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
        public Action<string> WriteLine { get; init; } = text => Console.WriteLine(text);
        public Func<string>? ReadLine { get; init; } = () => Console.ReadLine()!;
        public Program() 
        {
            
        }
    }
}
