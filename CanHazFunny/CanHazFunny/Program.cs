using CanHazFunny;

namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            new Jester(new Output(), new JokeService()).TellJoke();
        }
    }
}
