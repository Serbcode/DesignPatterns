using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern1
{
    class PlayingState : State
    {
        public PlayingState(AudioPlayer audioPlayer) : base (audioPlayer)
        {
        }

        public override void ClickLock()
        {
            Player.ChangeState(new LockedState(Player));
            System.Console.WriteLine("player now locked.");
        }

        public override void ClickNext()
        {
            Player.NextSong();
            System.Console.WriteLine("playing next song.");
        }

        public override void ClickPlay()
        {
            Player.StopPlayback();
            Player.ChangeState(new ReadyState(Player));
            System.Console.WriteLine("Paused...");
        }

        public override void ClickPrev()
        {
            Player.PreviousSong();
            System.Console.WriteLine("playing prev song.");
        }
    }
}
