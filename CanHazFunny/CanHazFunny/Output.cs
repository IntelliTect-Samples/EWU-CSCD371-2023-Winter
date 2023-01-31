using System;

namespace CanHazFunny
{
    public class Output : IOutput
    {
        public void Write(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}