namespace DefensiveProgramming
{
    public class ExchangeStudent : Student
    {
        public ExchangeStudent(string name) : base(name)
        {
            
        }

        public override bool CanEnroll(Semester semester) => semester != null;
    }
}