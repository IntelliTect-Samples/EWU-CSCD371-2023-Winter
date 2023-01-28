using System;

namespace CanHazFunny
{
    public class Jester : IJokeService
    {
        private IJokeOutput? _Output;
        public IJokeOutput Output {
            get => _Output!;
            set => _Output = value ?? throw new ArgumentNullException(nameof(Output));
        }
        private IJokeService? _Service;
        public IJokeService Service {
            get => _Service!;
            set => _Service = value ?? throw new ArgumentNullException(nameof(Service));
        } 
        public Jester(IJokeOutput? output, IJokeService? service) 
        {
            Output = output!;
            Service = service!;
        }

        public string GetJoke()
        {
            return Service.GetJoke();
        }

        public string TellJoke()
        {
            string joke;
            do
            {
                joke = GetJoke();
            } while (joke.Contains("Chuck Norris"));
            Output.TellJoke(joke);
            return joke;
        }
    }
}
