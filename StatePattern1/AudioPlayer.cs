namespace StatePattern1
{
    // Context class
    public class AudioPlayer
    {
        protected State State { get; set; }
        public bool IsLocked = false;
        public bool IsPlaying = false;

        public AudioPlayer()
        {
            State = new ReadyState(this);
        }

        public virtual void ChangeState(State state)
        {
            if (state is null)
            {
                throw new System.ArgumentNullException(nameof(state));
            }

            this.State = state;
        }

        public void SetPlaying(bool playing)
        {
            this.IsPlaying = playing;
        }

        public void SetLocked(bool locked)
        {
            this.IsLocked = locked;
        }

        public void ClickLock() => State.ClickLock();
        public void ClickPlay() => State.ClickPlay();
        public void ClickNext() => State.ClickNext();
        public void ClickPrev() => State.ClickPrev();        

        #region Service methods
        public void StartPlayback()
        {
            IsPlaying = true;
        }

        public void StopPlayback()
        {
        }

        public void NextSong()
        {
        }

        public void PreviousSong()
        {
        }

        public void Lock()
        {
        }
        #endregion

    }
}
