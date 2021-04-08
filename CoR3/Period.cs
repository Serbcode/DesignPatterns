using System;

namespace CoR3
{
    public class Period
    {
        static readonly string format = "dd.MM.yyyy";

        public readonly DateTime? Start;
        public readonly DateTime? End;

        public Period(DateTime? start, DateTime? end)
        {
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            string s = Start.HasValue ? Start.Value.ToString(format) : "null";
            string e = End.HasValue ? End.Value.ToString(format) : "null";
            return $"[{s} - {e}]";
        }

        public bool IsValid
        {
            get
            {
                return (Start.HasValue) && (End.HasValue);
            }
        }
    }
}
