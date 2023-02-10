namespace Logger;
public record class Book(string Title, string Author, string Publisher, string ISBN) : IEntity
{
    public string Title { get; } = Title ?? throw new ArgumentNullException(nameof(Title));
    public string Author { get; } = Author ?? throw new ArgumentNullException(nameof(Author));
    public string Publisher { get; } = Publisher ?? throw new ArgumentNullException(nameof(Publisher));
    public string ISBN { get; } = ISBN ?? throw new ArgumentNullException(nameof(ISBN));


    //Implicit, to avoid a backing field and instead use "computed"/"calculated" property, forming the book's
      //"name" from it's title and author
    public string Name { 
        get { return Title + " by " + Author; } 
    }

    //Explicit, because no regular user would probably care at all about an entity id, or even know what a guid was
    //ergo it can be "hidden" in the interface so only somebody searching for this specific interface functionality
    //would know and have to deal with it
    Guid IEntity.Id { get; init; } = Guid.NewGuid();
}