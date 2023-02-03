namespace CanHazFunny
{
    internal static class Program
    {
        private static void Main()
        {
            new Jester(new Output(), new JokeService()).TellJoke();
        }
    }
}
