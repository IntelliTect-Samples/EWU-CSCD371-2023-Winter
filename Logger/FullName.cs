using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;


public record struct FullName(string First, string Last, string Middle)
{
    public string First { get; } = First ?? throw new ArgumentNullException(nameof(First));
    public string Last { get; } = Last ?? throw new ArgumentNullException(nameof(Last));
    public string Middle { get; }
}