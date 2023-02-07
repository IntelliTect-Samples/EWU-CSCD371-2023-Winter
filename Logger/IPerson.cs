namespace Logger;

public interface IPerson
{
    public string BuildName(FullName fullName)
    {
        return fullName.MiddleName is null
            ? string.Format($"{fullName.FirstName} {fullName.LastName}")
            : string.Format($"{fullName.FirstName} {fullName.MiddleName} {fullName.LastName}");
    }
}