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
        Service.Display(joke);
    }
}