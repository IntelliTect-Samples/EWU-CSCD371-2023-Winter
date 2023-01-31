using System;
using System.Diagnostics;

namespace CanHazFunny
{
    public class Jester
    {
        private readonly IOutput _output;
        private readonly IJokeService _jokeService;

        public Jester(IOutput output, IJokeService jokeService)
        {
            if (output == null) {throw new ArgumentNullException(nameof(output));}
            if (jokeService == null) {throw new ArgumentNullException(nameof(jokeService));}
            
            _output = output;
            _jokeService = jokeService;
            
        }

        public void TellJoke()
        {
            string joke;
            while ((joke = _jokeService.GetJoke()).ToLower().Contains("chuck norris")) {}
            _output.Write(joke);
        }
    }
}