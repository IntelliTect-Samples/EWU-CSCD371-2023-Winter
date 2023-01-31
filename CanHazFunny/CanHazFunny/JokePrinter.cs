using System;

namespace CanHazFunny
{
    internal class JokePrinter : IPrintJoke
    {
        public void printJoke(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}
