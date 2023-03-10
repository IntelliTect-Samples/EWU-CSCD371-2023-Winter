using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_06_LambdaExpressions;
internal class Program
{
    public static void Main(string[] args)
    {
        CancellationToken cancellationToken = new CancellationToken();
        while(true)
        {
            Console.WriteLine("doodoo");
            if (cancellationToken.IsCancellationRequested ) break;
        }

    }
}
