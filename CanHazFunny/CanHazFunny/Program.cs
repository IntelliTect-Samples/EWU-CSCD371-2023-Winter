using System;

namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            Jester jester = new Jester(new JokeOutput(), new JokeService());
            jester.TellJoke();
        }
    }
}
