using System.Net.Http;
using System;
[assembly: CLSCompliant(true)]

namespace CanHazFunny;

public class JokeService : IJokeRetrieve
{
    private HttpClient HttpClient { get; } = new();

    public virtual string GetJoke()
    {
        Uri newUri = new Uri("https://geek-jokes.sameerkumar.website/api?format=json");
        // string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        // string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        string jsonJoke = HttpClient.GetStringAsync(newUri).Result;
        return jsonJoke.Substring(9, (jsonJoke.Length - 11));
    }
}
