using System;
using System.Collections.Generic;

namespace CommandPattern3
{
    class Program
    {
        static void Main(string[] args)
        {
            // invoker
            var BashSession = new BashSession();
            
            // receiver
            BashTerminal terminal = new BashTerminal();

            // concrete commands
            Command cmd = CommandFactory.CreateCommand("redo", terminal);
            BashSession.ExecuteCommand(cmd);

            cmd = CommandFactory.CreateCommand("rm", terminal);
            BashSession.ExecuteCommand(cmd);

            cmd = CommandFactory.CreateCommand("history", terminal);
            BashSession.ExecuteCommand(cmd);


            //string cmdName;
            //do
            //{
            //    string cmd = Console.ReadLine();
            //    Command command = CommandFactory.CreateCommand(cmd);
            //    BashSession.ExecuteCommand(command);

            //    cmdName = command.Name();

            //} while (cmdName != "exit");            

        }
    }
}
