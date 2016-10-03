using System;

namespace CommunicatingBetweenComponents
{
    public class JobChangedEventArgs : EventArgs
    {
        public Job Job { get; set; }
    }
}