using System;

namespace CanHazFunny
{
    public class JokePrinter : IPrintJoke
    {
        public void printJoke(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}
