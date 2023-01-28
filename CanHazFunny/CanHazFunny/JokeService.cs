using System.Net.Http;
using System;
namespace CanHazFunny;

public class JokeService : IJokeRetrieve, IJokeDisplay
{
    private HttpClient HttpClient { get; } = new();

    public virtual string GetJoke()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        return joke;
    }

    public void Display(string joke)
    {
        Console.WriteLine($"{joke}"); 
    }
}
