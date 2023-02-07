namespace Logger;
public record class Book(string title, string author, string publisher, string isbn) : IEntity
{
    public string Title { get; set; } = title ?? throw new ArgumentNullException(nameof(title));
    public string Author { get; set; } = author ?? throw new ArgumentNullException(nameof(author));
    public string Publisher { get; set; } = publisher ?? throw new ArgumentNullException(nameof(publisher));
    public string ISBN { get; set; } = isbn ?? throw new ArgumentNullException(nameof(isbn));


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