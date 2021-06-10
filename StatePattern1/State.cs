namespace StatePattern1
{
    public abstract class State
    {
        protected AudioPlayer Player { get; }
    

        public State(AudioPlayer player)
        {
            Player = player;
        }

        public abstract void ClickLock();
        public abstract void ClickPlay();
        public abstract void ClickNext();
        public abstract void ClickPrev();
    }
}
