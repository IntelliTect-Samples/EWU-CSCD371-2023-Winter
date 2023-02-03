using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class JokeDisplayer : IJokeDisplay
{
    public void Display(string joke)
    {
        Console.WriteLine(joke);
    }
}
