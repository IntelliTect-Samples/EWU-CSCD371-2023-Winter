namespace CanHazFunny;

static class Program
{
    static void Main(string[] args)
    {
        Jester jester = new(new JokeService());

        jester.TellJoke();
        jester.TellJoke();
        jester.TellJoke();
    }
}
