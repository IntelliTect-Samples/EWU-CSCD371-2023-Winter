namespace Logger;
public record class Book(string Title, string Author, string Publisher, string ISBN) : IEntity
{
    public string Title { get; set; } = Title ?? throw new ArgumentNullException(nameof(Title));
    public string Author { get; set; } = Author ?? throw new ArgumentNullException(nameof(Author));
    public string Publisher { get; set; } = Publisher ?? throw new ArgumentNullException(nameof(Publisher));
    public string ISBN { get; set; } = ISBN ?? throw new ArgumentNullException(nameof(ISBN));


    //Implicit, to avoid a backing field and instead use "computed"/"calculated" property, forming the book's
      //"name" from it's title and author
    public string Name { 
        get { return Title + " by " + Author; } 
        set { string[] split = value.Split(" -by- ");
               Title = split[0];
               Author = split[1];
        }
    }
    
    //Explicit, because no regular user would probably care at all about an entity id, or even know what a guid was
      //ergo it can be "hidden" in the interface so only somebody searching for this specific interface functionality
      //would know and have to deal with it
    Guid IEntity.Id { get; init; }
}