using System;

namespace CommandPattern3.Commands
{
    /// <summary>
    /// Exit console
    /// </summary>
    public class ExitCommand : Command
    {
        public ExitCommand(string name) : base(name) { }

        public override string Execute()
        {
            return "Good buy!";
        }

    }
}