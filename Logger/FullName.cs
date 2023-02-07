using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;


// We chose to use a struct because we wanted value-based comparison and because 
// it is needed as a light-weight data type

// We made the class readonly (immutable) because we wanted to avoid the confusion
// that is associated with copying value types and dereferencing value types
public readonly record struct FullName(string First, string Last, string? Middle)
{
    public string First { get; } = First ?? throw new ArgumentNullException(nameof(First));
    public string Last { get; } = Last ?? throw new ArgumentNullException(nameof(Last));
    public string Middle { get; } = Middle ?? string.Empty;
}