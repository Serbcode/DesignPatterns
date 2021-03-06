﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern3.Commands
{
    /// <summary>
    /// Show help string
    /// </summary>
    public class HelpCommand : Command
    {
        public HelpCommand(string name) : base(name)
        {
        }

        public override string Execute()
        {
            return "Input command: [help, history, undo, rm, status, uptime, exit]";
        }
    }
}
