namespace DefensiveProgramming
{
    public interface IExamApplication
    {
        Subject Subject { get; }
        Professor Administrator { get; }
        Student Candidate { get; }
    }
}