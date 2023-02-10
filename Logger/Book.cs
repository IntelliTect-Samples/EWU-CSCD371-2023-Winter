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

    // Name is implemented implicitly because a book still has a type of "name", in this case a title
    public override string Name
    {
        get
        {
            return Title;
        }
    }
}