namespace StatePattern1
{
    public class LockedState : State
    {
        public LockedState(AudioPlayer audioPlayer) : base(audioPlayer)
        {
        }

        public override void ClickLock()
        {
            if (Player.IsLocked)
            {
                Player.SetLocked(false);
                Player.ChangeState(new ReadyState(Player));
                System.Console.WriteLine("player unlocked.");
            }
            else 
            {
                Player.SetLocked(true);
                Player.ChangeState(new LockedState(Player));
                System.Console.WriteLine("player now locked.");
            }
            
        }

        public override void ClickNext()
        {
            System.Console.WriteLine("player is locked");
        }

        public override void ClickPlay()
        {
            System.Console.WriteLine("player is locked");
        }

        public override void ClickPrev()
        {
            System.Console.WriteLine("player is locked");
        }
    }
}
