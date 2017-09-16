using System;
using DefensiveProgramming.Implementation;

namespace DefensiveProgramming
{
    public class ExamApplicationBuilder
    {
        private Professor Administrator { get; set; }
        private Subject Subject { get; set; }
        private Student Candidate { get; set; }


        public void AdministeredBy(Professor administrator)
        {
            this.Administrator = administrator;
        }

        public void OnSubject(Subject subject)
        {
            this.Subject = subject;

        }

        public void TakenBy(Student candidate)
        {
            this.Candidate = candidate;
        }

        public bool CanBuild() => this.Administrator != null && 
                                  this.Subject != null && 
                                  this.Candidate != null &&
                                  this.Candidate.Enrolled == this.Subject.TaughtDuring &&
                                  !this.Candidate.HasPassExaam(this.Subject) &&
                                  this.Subject.TaughtBy == this.Administrator;

        public IExamApplication Build()
        {
            if(!this.CanBuild())
            {
                throw new InvalidOperationException();
            }

            return new ExamApplication(this.Subject, 
                this.Administrator, 
                this.Candidate);
        }
    }
}