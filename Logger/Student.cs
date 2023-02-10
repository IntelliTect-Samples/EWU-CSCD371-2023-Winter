namespace Logger;
//We defined each record implicity to make sure data loss is preveneted and all data can be accessed
public record class Student : Person
{
    public GradeLevel StudentGrade { get; init; }
}
