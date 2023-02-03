using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CanHazFunny
{
    public class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            //This most assuredly isn't the proper or good way to do it but idk it kinda works and I can't get the 
            //stupid deserialization nonsense to work with the time left. So voila, jury-rigged solution.
            string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
            joke = joke.Remove(0, 10);
            joke = joke.Remove(joke.Length - 3, 2);
            return joke;
        }
    }
}