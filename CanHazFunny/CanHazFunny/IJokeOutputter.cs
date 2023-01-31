using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public interface IJokeOutputter
    {
        public void OutputJoke(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}
