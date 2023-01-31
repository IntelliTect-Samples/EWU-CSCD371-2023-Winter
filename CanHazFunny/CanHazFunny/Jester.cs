using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        private readonly IJokeService _jokeService;
        private readonly IJokeOutputter _jokeOutput;
        
        public Jester(IJokeService? jokeService, IJokeOutputter? jokeOutput)
        {
            if(jokeService is null)
            {
                throw new ArgumentNullException(nameof(jokeService));
            }
            if(jokeOutput is null)
            {
                throw new ArgumentNullException(nameof(jokeOutput));
            }
                _jokeService = jokeService;
                _jokeOutput = jokeOutput;
        }

        public void TellJoke()
        {
            string joke = "Chuck Norris";
            while(joke.Contains("Chuck Norris"))
            {              
                joke = _jokeService.GetJoke();
            }
            
            _jokeOutput.OutputJoke(joke);
        }
    }
}
