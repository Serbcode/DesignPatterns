using System;

namespace StatePattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            AudioPlayer player = new AudioPlayer();
            player.ClickPlay();
            player.ClickLock();
            player.ClickNext();
            player.ClickLock();
            player.ClickPrev();
            player.ClickPlay();
        }
    }
}
