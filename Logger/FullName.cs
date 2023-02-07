namespace Logger;

// Why we chose struct:
// 1. For an optimized lightweight type that does value-based comparison.
// 2. Full names will be passed around like data, and it should not be derived from.

// Why we chose to make our record immutable:
// 1. To avoid the confusion associated with copying and dereferencing value types.
// 2. To prevent modification of the struct after it's been created.


public readonly record struct FullName(string First, string Last, string? Middle = null)
{
    public string First { get; } = First ?? throw new ArgumentNullException(nameof(First));
    public string Last { get; } = Last ?? throw new ArgumentNullException(nameof(Last));
    public string? Middle { get; } = Middle;

    public override string ToString()
    {
        if (Middle is null)
            return $"{First} {Last}";
        return $"{First} {Middle} {Last}";
    }
}