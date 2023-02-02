using System;
namespace CanHazFunny;

public class Jester
{
	public JokeService _jokeService { get; set; }
	public JokeOutput _jokeOutput { get; set; }

	public Jester (JokeService jokeService, JokeOutput jokeOutput)
	{
		if(jokeService is null)
		{
			throw new ArgumentNullException(nameof(_jokeService));
		}
		if (jokeOutput is null)
		{
            throw new ArgumentNullException(nameof(_jokeOutput));
        }
		_jokeService = jokeService;
		_jokeOutput = jokeOutput;
	}

	public void TellJoke()
	{
	
        string joke = _jokeService.GetJoke();

                    while (joke.Contains("Chuck") || joke.Contains("Norris") || joke.Contains("chuck") || joke.Contains("norris")) 
			{
				joke = _jokeService.GetJoke();
			}
			Console.WriteLine(joke);
	}

}
