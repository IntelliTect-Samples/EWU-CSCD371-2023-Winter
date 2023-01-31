using System;

namespace CanHazFunny
{
    public class Jester
    {
        private IPrintJoke? printService;
        private IJokeService? jokeService;

        public IPrintJoke PrintService { get => printService!; set => printService = value; }
        public IJokeService JokeService { get => jokeService!; set => jokeService = value; }

        public Jester(IPrintJoke printService, IJokeService jokeService)
        {
            if (printService is null)
            {
                throw new ArgumentNullException(nameof(printService));
            }
            if (jokeService is null)
            {
                throw new ArgumentNullException(nameof(jokeService));
            }

            PrintService = printService;
            JokeService = jokeService;
        }

        public void TellJoke()
        {
            string joke = JokeService.GetJoke();
            while(joke.ToLower().Contains("chuck") || joke.ToLower().Contains("norris"))
            {
                joke = JokeService.GetJoke();
            }
            PrintService.printJoke(joke);
        }
    }
}
