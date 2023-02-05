﻿namespace Logger;

public record class Employee(int EID, FullName FName) : Person(FName)
{
    public override string ToString() => "Employee ID: " + EID + base.ToString();
    public virtual bool Equals(Employee? other)
    {
        if (other is null) return false;
        return (Name, EID) == (other?.Name, other?.EID);
    }
  
    public override int GetHashCode() => HashCode.Combine(EID.GetHashCode(), base.GetHashCode());
}
