using System;

namespace CommandPattern3.Commands
{
    public class HistoryCommand : Command
    {
        public HistoryCommand(string name, BashSession bashSession) : base(name, bashSession)
        {
        }

        public override string Execute()
        {
            return session.GetHistory();
        }
    }
}