using System;

namespace CommunicatingBetweenComponents
{
    public sealed class Mediator
    {
        private static readonly Mediator _instance = new Mediator();

        private Mediator(){}

        public static Mediator GetInstance()
        {
            return _instance;
        }

        // instance functionality
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {

            var jobChangedDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            if (jobChangedDelegate != null)
                jobChangedDelegate(sender,new JobChangedEventArgs() { Job = job});

        }


    }
}