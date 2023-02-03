namespace CanHazFunny;

static class Program
{
    static void Main(string[] args)
    {
        Jester jester = new(new JokeService(), new JokeDisplayer());

        jester.TellJoke();
        jester.TellJoke();
        jester.TellJoke();
    }
}
