using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class Jester
{
    private IJoke? _Joke;
    private IOutput? _Output;

    public Jester(IJoke joke, IOutput output)
    {
        Joke = joke;
        Output = output;
    }

    public IJoke Joke
    {
        get
        {
            return _Joke!;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(nameof(value));
            _Joke = value;
        }
    }

    public IOutput Output
    {
        get
        {
            return _Output!;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(nameof(value));
            _Output = value;
        }
    }

    public string TellJoke()
    {
        string joke = Joke.GetJoke();
        while (joke.Contains("Chuck Norris"))
        {
            joke = Joke.GetJoke();
        }
        Output.Write(joke);
        return joke;
    }
}
