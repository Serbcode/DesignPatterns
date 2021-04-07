using System;

namespace CommandPattern3.Commands
{
    /// <summary>
    /// show terminal session working time
    /// </summary>
    public class UptimeCommand : Command
    {
        public UptimeCommand(string name, Session session) : base(name, session)
        {
        }

        public override string Execute()
        {
            return "Uptime command executed: " + session.Terminal.Uptime.Elapsed;
        }
    }
}