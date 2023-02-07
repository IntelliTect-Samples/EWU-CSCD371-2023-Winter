namespace Logger;

public record class Book(string Title, string Author, string ISBN) : BaseEntity, IEquatable<Book>
{
    public string Title { get; } = Title ?? throw new ArgumentNullException(nameof(Title));
    public string Author { get; } = Author ?? throw new ArgumentNullException(nameof(Author));
    public string ISBN { get; } = ISBN ?? throw new ArgumentNullException(nameof(ISBN));

    // Implemented implicitely because we don't want to hide this member from the users of the class
    public override string Name { get => $"{Title} by {Author} ({ISBN})"; }

    public virtual bool Equals(Book? other)
    {
        if (other == null) return false;
        return ISBN.Equals(other.ISBN);
    }

    public override int GetHashCode()
    {
        return ISBN.GetHashCode();
    }
}
