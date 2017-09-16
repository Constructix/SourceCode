using System;
using DefensiveProgramming.Implementation;

namespace DefensiveProgramming
{
    public abstract class Student
    {
        public string Name { get; private set; }
        public Semester Enrolled { get; private set; }

     


        protected Student(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException();
            
            this.Name = name;
        }
        public void Enroll(Semester semester)
        {
            if(!this.CanEnroll(semester))
                throw new ArgumentException();
            this.Enrolled = semester;

            
        }

        public IExamApplication ApplyFor(Subject examOn, Professor administeredBy)
        {
            ExamApplicationBuilder builder = new ExamApplicationBuilder();
            builder.OnSubject(examOn);
            builder.AdministeredBy(administeredBy);
            builder.TakenBy(this);
           

            
            if (builder.CanBuild())
            {
                return builder.Build();
            }
            else
            {
                throw new ArgumentException();
            }
        }


        public Func<IExamApplication> GetExamApplicatonFactory(Subject examOn, Professor administeredBy)
        {
            ExamApplicationBuilder builder = new ExamApplicationBuilder();
            builder.OnSubject(examOn);
            builder.AdministeredBy(administeredBy);
            builder.TakenBy(this);

            if(!builder.CanBuild())
                throw new ArgumentException();
            return builder.Build;
        }


        public abstract bool CanEnroll(Semester semester);

        public int NameLength => this.Name.Length;
        public char NameInitialLetter => this.Name[0];

        public bool HasPassExaam(Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}