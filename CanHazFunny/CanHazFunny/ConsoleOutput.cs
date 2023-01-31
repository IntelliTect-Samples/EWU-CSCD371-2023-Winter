using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class ConsoleOutput : IOutput
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}
