using System;

namespace CSharpNewFeatures
{
    public class PointEventArgs : EventArgs
    {
        public Point Point { get; set; }
        public string Message { get; set; }
    }
}