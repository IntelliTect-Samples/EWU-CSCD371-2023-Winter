using System;

namespace CanHazFunny
{
    public class JokePrinter : IPrintJoke
    {
        public void PrintJoke(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}
