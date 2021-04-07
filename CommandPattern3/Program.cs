using System;
using System.Collections.Generic;
using CommandPattern3.Commands;

namespace CommandPattern3
{
    class Program
    {
        static void Main(string[] args)
        {
            // receiver
            BashTerminal terminal = new BashTerminal();

            // invoker
            var Session = new BashSession(terminal);                        

            string name = string.Empty;
            do
            {
                string input = Console.ReadLine();
                Command command = CommandFactory.CreateCommand(input.ToLower(), Session);

                if (command == null) continue;
                name = command.ToString();
                
                Session.ExecuteCommand(command);               

            } while (name != "exit");

        }
    }
}
