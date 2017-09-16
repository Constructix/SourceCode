namespace DefensiveProgramming
{
    public class RegularStudent : Student
    {
        public RegularStudent(string name) : base(name)
        {
            
        }

        public override bool CanEnroll(Semester semester) => semester != null && semester.Predecessor == base.Enrolled;
    }
}