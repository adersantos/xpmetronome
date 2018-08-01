using System;
using System.Threading;

namespace XPMetronome.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var configMetronomo = new ConfiguracaoMetronomo();

            System.Console.WriteLine("Tipo Compasso: ");
            configMetronomo.TipoCompasso = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Velocidade: ");
            configMetronomo.Velocidade = int.Parse(System.Console.ReadLine());


            Note[] metronomo = { new Note(Tone.C,Duration.QUARTER),
                                 new Note(Tone.D,Duration.QUARTER),
                                 new Note(Tone.E,Duration.QUARTER),
                                 new Note(Tone.F,Duration.QUARTER),
                                 new Note(Tone.G,Duration.QUARTER),
                                 new Note(Tone.A2,Duration.QUARTER),
                                 new Note(Tone.B2,Duration.QUARTER),
                                 new Note(Tone.C2,Duration.QUARTER)};
            Play(metronomo);
        }

        private static void Play(Note[] metronomo)
        {
            foreach (var nota in metronomo)
            {
                if (nota.NoteTone == Tone.REST)
                    Thread.Sleep((int)nota.NoteDuration);
                else
                    System.Console.Beep((int)nota.NoteTone, (int)nota.NoteDuration);
            }
        }

        private static void ExecutarBeep(int tipoCompasso, int velocidade)
        {
            int frequencia = 0;
            int duracao = 0;
            var compasso = int.Parse(tipoCompasso.ToString().PadRight(1));
            for (int i = 0; i < compasso; i++)
            {
                Thread.Sleep(500);
                System.Console.Beep(frequencia, duracao);
            }
        }

        #region Structure
        protected struct Note
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
        #endregion

        #region Enum
        protected enum Tone
        {
            REST = 0,
            GbelowC = 196,
            A = 220,
            A2 = A*2,
            Asharp = 233,
            B = 247,
            B2 = B*2,
            C = 262,
            C2 = C*2,
            Csharp = 277,
            D = 294,
            Dsharp = 311,
            E = 330,
            F = 349,
            Fsharp = 370,
            G = 392,
            Gsharp = 415,
        }
        protected enum Duration
        {
            WHOLE = 1600,
            HALF = WHOLE / 2,
            QUARTER = HALF / 2,
            EIGHTH = QUARTER / 2,
            SIXTEENTH = EIGHTH / 2,
        }
        #endregion

        public class ConfiguracaoMetronomo
        {
            public int TipoCompasso { get; set; }
            public int Velocidade { get; set; }
        }

    }
    
}
