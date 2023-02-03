using System;

namespace CanHazFunny
{
    public class Jester
    {
        private readonly IPrintJoke _PrintService;
        private readonly IJokeService _JokeService;

        public Jester(IPrintJoke printService, IJokeService jokeService)
        {
            _PrintService = printService ?? throw new ArgumentNullException(nameof(printService));
            _JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        }

        public void TellJoke()
        {
            string joke = _JokeService.GetJoke();
            while(joke.ToLower().Contains("chuck") || joke.ToLower().Contains("norris"))
            {
                joke = _JokeService.GetJoke();
            }
            _PrintService.PrintJoke(joke);
        }
    }
}
