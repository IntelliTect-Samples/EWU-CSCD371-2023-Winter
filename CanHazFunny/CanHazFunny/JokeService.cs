using System.Net.Http;
using System;
namespace CanHazFunny
{
    public class JokeService : JokeServiceInterface, JokeServiceDisplay
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
            return joke;
        }

        public void Display()
        {
            Console.WriteLine($"{this.GetJoke()}");
        }
    }
}
