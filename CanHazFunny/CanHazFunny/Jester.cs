using System;

namespace CanHazFunny
{
    public class Jester
    {
        private readonly IOutput _output;
        private readonly IJokeService _jokeService;

        public Jester(IOutput? output, IJokeService? jokeService)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        }

        public void TellJoke()
        {
            string joke;
            while ((joke = _jokeService.GetJoke()).ToLower().Contains("chuck norris")) {}

            _output.Write(joke);
        }
    }
}