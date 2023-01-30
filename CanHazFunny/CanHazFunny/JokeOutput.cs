using System;
namespace CanHazFunny;

public class JokeOutput : IJokeOutput
{
	public void Write(string output)
	{
		Console.WriteLine(output);
	}
}
