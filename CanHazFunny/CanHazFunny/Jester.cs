using System;
namespace CanHazFunny;

public class Jester
{
	public JokeService _jokeService { get; set; } = default!;
	public JokeOutput _jokeOutput { get; set; } = default!;

	public Jester (JokeService _jokeService, JokeOutput _jokeOutput)
	{
		_jokeService = _jokeService ?? throw new ArgumentNullException(nameof(_jokeService)); 
		_jokeOutput = _jokeOutput ?? throw new ArgumentNullException(nameof(_jokeOutput));
	}

	public void TellJoke()
	{
		string joke = _jokeService.GetJoke();

		while(joke.Contains("Chuck Norris"))
		{
			joke = _jokeService.GetJoke();
		}
		Console.WriteLine(joke);
	}

}
