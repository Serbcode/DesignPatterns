using System;
using System.Collections.Generic;
using CommandPattern3.Commands;

namespace CommandPattern3
{
    /// <summary>
    /// Invoker class
    /// </summary>
    public class Session
    {
        protected readonly List<string> history = new List<string>();

        public Session(Terminal terminal)
        {
            Terminal = terminal;
        }

        public Terminal Terminal { get; }

        public void ExecuteCommand(Command cmd)
        {
            Console.WriteLine(cmd.Execute());
            history.Add(cmd.Name);
            Terminal.PushCommand(cmd);
        }

        public string GetHistory()
        {
            return string.Join(" -> ", history);
        }
    }
}