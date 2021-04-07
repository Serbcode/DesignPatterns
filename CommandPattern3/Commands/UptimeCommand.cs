using System;

namespace CommandPattern3.Commands
{
    public class UptimeCommand : Command
    {
        public UptimeCommand(string name, BashSession session) : base(name, session)
        {
        }

        public override string Execute()
        {
            return "Uptime command executed: " + session.Terminal.Uptime.Elapsed;
        }
    }
}