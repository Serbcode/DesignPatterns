using System;

namespace StatePattern1
{
    public class ReadyState : State
    {
        public ReadyState(AudioPlayer audioPlayer) : base (audioPlayer)
        {
        }

        public override void ClickLock()
        {
            Player.ChangeState(new LockedState(Player));
            Player.IsLocked
                = true;
            Console.WriteLine("player is now locked.");
        }

        public override void ClickPlay()
        {
            Player.StartPlayback();
            Player.ChangeState(new LockedState(Player));
            Console.WriteLine("player starts playing");
        }

        public override void ClickNext()
        {
            Player.NextSong();
            Console.WriteLine("Jump to next song");
        }

        public override void ClickPrev()
        {
            Player.PreviousSong();
            Console.WriteLine("jump to prev song");
        }
    }
}
