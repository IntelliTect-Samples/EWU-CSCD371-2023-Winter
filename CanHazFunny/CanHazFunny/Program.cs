using System;

namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Jester(new JokePrinter(), new JokeService()).TellJoke();
            }
        }
    }
}
