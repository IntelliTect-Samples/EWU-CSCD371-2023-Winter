namespace Logger;

public record class Book : BaseEntity
{
    public Book(Guid id, string title, FullName author)
    {
        Id = id;
        Title = title;
        AuthorName = author;
    }

    public string Title { get; }
    public FullName AuthorName { get; }

    public override string Name
    {
        get
        {
            return AuthorName.MiddleName is null
                ? string.Format($"{Title} by {AuthorName.FirstName} {AuthorName.LastName}")
                : string.Format($"{Title} by {AuthorName.FirstName} {AuthorName.MiddleName} {AuthorName.LastName}");
        }
    }
}