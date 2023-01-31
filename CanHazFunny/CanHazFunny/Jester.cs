using System;

namespace CanHazFunny
{
    internal class Jester
    {
        private IPrintJoke printService;
        private IJokeService jokeService;

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

            this.printService = printService;
            this.jokeService = jokeService;
        }
    }
}
