﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        public IService JokeService { 
            get => _jokeService; 
            set => _jokeService = value ?? throw new ArgumentNullException(value.ToString());
        }
        private JokeService? _jokeService;
        public IServiceWriter JokeServiceWriter {
            get => _jokeServiceWriter; 
            set => _jokeServiceWriter = value ?? throw new ArgumentNullException(value.ToString());
        }
        private IServiceWriter? _JokeServiceWriter;

        public Jester(JokeService jokeService, JokeServiceWriter jokeServiceWriter) 
        {
            JokeService = jokeService;
            JokeServiceWriter = jokeServiceWriter;
        }

        public void TellJoke()
        {
            string joke = JokeService.GetJoke();
            while (joke.Contains("Chuck Norris", StringComparison.CurrentCulture))
            {
                joke = JokeService.GetJoke();
            }
            JokeServiceWriter.TellJoke(joke);
        }
    }
}
