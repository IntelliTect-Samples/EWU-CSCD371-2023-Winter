using System.Net.Http;
using System;
using System.IO;

namespace CanHazFunny;

public class JokeService : IJokeRetrieve, IJokeDisplay
{
    private HttpClient HttpClient { get; } = new();

    public virtual string GetJoke()
    {
        // string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        return joke;
    }

    public void Display(string joke)
    {
        Console.WriteLine($"{joke}"); 
    }
}
