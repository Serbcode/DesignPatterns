using System;

namespace VisitorPattern2
{
    public readonly struct Period
    { 
        public DateTime? StartDate { get;  }
        public DateTime? EndDate { get;  }

        public Period(DateTime? Start, DateTime? End)
        {
            StartDate = Start;
            EndDate = End;
        }

        public override string ToString()
        {
            return $"({StartDate?.ToShortDateString()}, {EndDate?.ToShortDateString()})";
        }
    }
}
