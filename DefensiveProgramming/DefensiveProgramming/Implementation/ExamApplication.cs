namespace DefensiveProgramming.Implementation
{
    public class ExamApplication : IExamApplication
    {
        public ExamApplication(Subject subject, Professor administrator, Student candidate)
        {
            this.Subject = subject;
            this.Administrator = administrator;
            this.Candidate = candidate;
        }

        public Subject Subject { get; }
        public Professor Administrator { get; }
        public Student Candidate { get; }
    }

   
}