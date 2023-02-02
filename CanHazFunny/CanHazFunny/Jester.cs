using System;
using System.Reflection.Metadata.Ecma335;

namespace CanHazFunny;

public class Jester
{
    public IJokeService JokeService { get; }
    public IJokeOutput JokeOutput { get; }
    public Jester(IJokeService? _jokeService,IJokeOutput? _jokeOutput)
	{
        JokeService = _jokeService ?? throw new ArgumentNullException(nameof(_jokeService));
        JokeOutput = _jokeOutput ?? throw new ArgumentNullException(nameof(_jokeOutput));
    }
    public string? Joke { get; set; }
    public void TellJoke()
    {
        Joke = JokeService.GetJoke();

        while (Joke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase) | 
            Joke.Contains("Chuck", StringComparison.OrdinalIgnoreCase) |
            Joke.Contains("Norris", StringComparison.OrdinalIgnoreCase))
        {
            Joke = JokeService.GetJoke();
        }

        JokeOutput.Write(Joke);
    }
    

}
