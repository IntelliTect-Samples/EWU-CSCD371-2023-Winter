using System;
using System.IO;

namespace CanHazFunny
{
    public class JokeOutput : IJokeOutput
    {
        private StreamWriter? _Stream;
        public StreamWriter? Stream
        {
            get => _Stream!;
            set => _Stream = value ?? throw new ArgumentNullException(nameof(Stream));
        }
        public void TellJoke(string joke)
        {
            if(Stream == null)
            {
                Console.WriteLine(joke);
            } else
            {
                Stream.WriteLine(joke);
                Stream.Flush();
            }
        }
    }
}
