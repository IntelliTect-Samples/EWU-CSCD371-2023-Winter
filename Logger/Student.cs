namespace Logger
{
    public record class Student : Person
    {
        public GradeLevel StudentGrade { get; init; }
    }
}
