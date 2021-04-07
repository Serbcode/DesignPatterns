using System;

namespace CommandPattern3.Commands
{
    /// <summary>
    /// Show all commands entered.
    /// </summary>
    public class HistoryCommand : Command
    {
        public HistoryCommand(string name, Session bashSession) : base(name, bashSession)
        {
        }

        public override string Execute()
        {
            return session.GetHistory();
        }
    }
}