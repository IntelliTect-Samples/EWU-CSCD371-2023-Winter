using System;

namespace CanHazFunny;

	public class JokeOutput : IJokeOutput
	{
		public void TellJoke(string joke)
		{
			Console.WriteLine(joke);
		}
	}