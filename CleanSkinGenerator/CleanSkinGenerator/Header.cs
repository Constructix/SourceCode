using System.Collections.Generic;
using System.Net;

namespace CleanSkinGenerator
{
    public class Header
    {
        public int SequenceNumber { get; set; }
        public string ReportLabel { get; set; }

        public Header(int sequenceNumber, string reportLabel) : this()
        {
            SequenceNumber = sequenceNumber;
            ReportLabel = reportLabel;
        }

        public List<Tuple> Tuples { get; set; }
        public List<Fact> Facts { get; set; }

        public Header()
        {
            Tuples = new List<Tuple>();
            Facts = new List<Fact>();
        }
    }
}