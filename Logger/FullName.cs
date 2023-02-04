﻿namespace Logger;
public record class FullName(string FirstName, string LastName, string? MiddleName = null)
{
    /*
     * We chose to make FullName() a record class so that we gain the benefit of 
     * being able to pass a FullName() object by reference, but are able to compare
     * the fields FirstName, MiddleName, and LastName by value type equality.
     */
    /*
     * The FullName() record class is immutable because there are no setters for any 
     * of its properties. This means that the values of FirstName, MiddleName, or LastName 
     * cannot be changed once the FullName() object has been instantiated.
     */
    public string FirstName { get; } = FirstName??throw new ArgumentNullException(nameof(FirstName));
    public string LastName { get; } = LastName??throw new ArgumentNullException(nameof(LastName));
    public string? MiddleName { get; } = MiddleName;
}
