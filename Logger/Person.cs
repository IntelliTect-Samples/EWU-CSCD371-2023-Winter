namespace Logger
{

    //implemented implicitely so other entities could use it
    public record class Person : IEntity

    {
        public Guid Id { get; init; }
        public FullName FullName { get; init; }

        string IEntity.Name => FullName.Name;
    }
}
