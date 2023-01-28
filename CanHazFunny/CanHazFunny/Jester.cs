using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester : IJokeOutput, IJokeService
    {
        public Jester() 
        {
            _Joke = this.GetJoke();
        }

        public string Joke 
        {
            get 
            {
                return _Joke!;
            }
            set
            {
                if(value is null) 
                {
                    throw new ArgumentNullException(nameof(Joke));
                }
                _Joke = value;
            }
        }
        private string? _Joke;

        public string GetJoke()
        {
            JokeService thejoke = new JokeService();
            return thejoke.GetJoke();
        }

        public string TellJoke()
        {
            while(Joke.Contains("Chuck Norris"))
            {
                Joke = GetJoke();
            }
            return Joke;
        }
    }
}
