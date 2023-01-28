using System;

namespace CanHazFunny;

public class Jester
{
    private JokeService? _Service;
    public JokeService Service 
    { 
        get => _Service!;
        set => _Service = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Jester(JokeService service)
    {
        Service = service;
    }

    public void TellJoke()
    {
        string joke = Service.GetJoke();

        if (JokeFilter(joke))
        {
            Service.Display(joke);
        }
        else
        {
            Service.Display("That wasn't a very good joke, let me think of another one.");
        }
    }

    public static bool JokeFilter(string joke)
    {
        if (!string.IsNullOrWhiteSpace(joke) &&
            !joke.Contains("Chuck Norris", StringComparison.CurrentCultureIgnoreCase))
        {
            return true;
        }
        return false;
    }
}