using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EventsDelegatesAndLambdas.Tests
{
    public enum WorkType
    {
        Hours,
        Day
    }

    public delegate void WorkPerformedHandler(int hours, WorkType workType);

    [TestFixture]
    public class DelegateTest
    {
        [Test]
        public void CreateDelegate()
        {
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);

            DoWork(del1);
        }

        void DoWork(WorkPerformedHandler del)
        {
            del(5, WorkType.Day);
        }

        private void WorkPerformed2(int hours, WorkType worktype)
        {
            Console.WriteLine($"WorkPerformed2 callled {hours}");
        }


        public void WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPerformed1 called {hours}");
        }
    }
}