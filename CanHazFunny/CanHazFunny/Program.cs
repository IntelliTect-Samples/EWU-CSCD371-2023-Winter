﻿using System;
namespace CanHazFunny;
class Program
{
    static void Main(string[] args)
    {
        // Feel free to use your own setup here - this is just provided as an example
        // new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
        
        Jester joke = new Jester();
        
        joke.TellJoke();
        joke.TellJoke();
        joke.TellJoke();
        
        string someJoke = joke.GetJoke();
        joke.PrintJoke(someJoke);
    }
}

