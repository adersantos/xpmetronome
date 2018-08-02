namespace XPMetronome.Domain
{
    public class Note
    {
        Tone toneVal;
        Duration durVal;

        public Note(Tone frequency, Duration time)
        {
            toneVal = frequency;
            durVal = time;
        }
        public Tone NoteTone { get { return toneVal; } }

        public Duration NoteDuration { get { return durVal; } }
    }
}
