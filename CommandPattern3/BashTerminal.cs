using System.Collections.Generic;

namespace CommandPattern3
{
    /// <summary>
    /// Reciever, who recive commands and do some job
    /// </summary>
    public class BashTerminal
    {
        private readonly Queue<Command> queue;

        public BashTerminal()
        {
            queue = new Queue<Command>();
        }



    }
}