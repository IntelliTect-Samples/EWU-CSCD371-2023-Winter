using System;

namespace CanHazFunny;

public class Jester
{
    private IJokeRetrieve? _JokeRetriever;
    public IJokeRetrieve JokeRetriever 
    { 
        get => _JokeRetriever!;
        set => _JokeRetriever = value ?? throw new ArgumentNullException(nameof(value));
    }

    private IJokeDisplay? _JokeDisplayer;
    public IJokeDisplay JokeDisplayer
    {
        get => _JokeDisplayer!;
        set => _JokeDisplayer = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Jester(IJokeRetrieve jokeRetriever, IJokeDisplay jokeDisplayer)
    {
        JokeRetriever = jokeRetriever;
        JokeDisplayer = jokeDisplayer;
    }

    public void TellJoke()
    {
        string joke;
        do
        {
            joke = JokeRetriever.GetJoke();
        } while (JokeFilter(joke) == false);

        JokeDisplayer.Display(joke);
    }

    public static bool JokeFilter(string joke)
    {
        if (string.IsNullOrWhiteSpace(joke) ||
            joke.Contains("Chuck", StringComparison.CurrentCultureIgnoreCase) ||
            joke.Contains("Norris", StringComparison.CurrentCultureIgnoreCase))
        {
            return false;
        }
        return true;
    }
}