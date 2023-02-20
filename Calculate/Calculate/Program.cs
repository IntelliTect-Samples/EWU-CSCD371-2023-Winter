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
            string test = prog.ReadLine!();
            Calculator calc = new();
            float result;
            calc.TryCalculate(test, out result);
            prog.WriteLine!(result.ToString());

        }
        public Action<string>? WriteLine { get; init; }
        public Func<string>? ReadLine { get; init; }
        public Program() 
        {
            WriteLine = Console.WriteLine;
            ReadLine = Console.ReadLine!;
        }
    }
}
