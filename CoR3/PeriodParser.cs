namespace CoR3
{
    public abstract class PeriodParser
    {
        protected PeriodParser NextParser;

        public virtual Period Parse(string input)
        {
            if (NextParser == null) return new Period(null, null);
            else return NextParser.Parse(input);
        }

        public virtual PeriodParser SetNext(PeriodParser next)
        {
            NextParser = next;
            return next;
        }
    }
}
