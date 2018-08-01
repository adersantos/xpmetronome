using System;
using System.Text;
using System.Threading;
using XPMetronome.Domain;

namespace XPMetronome.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var configMetronomo = new ConfiguracaoMetronomo();
            string escalaMetronomo = string.Empty;

            System.Console.WriteLine("Escala ou Metronomo: (E/M)");
            escalaMetronomo = System.Console.ReadLine();

            if (escalaMetronomo == "E" || escalaMetronomo == "e")
            {
                StringBuilder strB = new StringBuilder();
                strB.Append(Constants.ESCOLHA_ESCALA + Constants.QUEBRA_LINHA);
                strB.Append(Constants.ESCALA_MAIOR_NATURAL + Constants.QUEBRA_LINHA);
                strB.Append(Constants.ESCALA_MENOR_NATURAL + Constants.QUEBRA_LINHA);
                strB.Append(Constants.ESCALA_MENOR_MELODICA + Constants.QUEBRA_LINHA);
                strB.Append(Constants.ESCALA_MENOR_HARMONICA + Constants.QUEBRA_LINHA);
                strB.Append(Constants.ESCALA_PENTATONICA_MAIOR + Constants.QUEBRA_LINHA);
                strB.Append(Constants.ESCALA_PENTATONICA_MENOR + Constants.QUEBRA_LINHA);
                strB.Append(Constants.PENTATONICA_MAIOR_BLUES + Constants.QUEBRA_LINHA);
                strB.Append(Constants.PENTATONICA_MENOR_BLUES + Constants.QUEBRA_LINHA);
                System.Console.WriteLine(strB);

                var escalaSelecionada = System.Console.ReadLine();
                Escala valorEscala =(Escala) Enum.Parse(typeof(Escala), escalaSelecionada);

                ObterEscalaSelecionada(valorEscala);
            }
            else
            {
                System.Console.WriteLine("Tipo Compasso: ");
                configMetronomo.TipoCompasso = int.Parse(System.Console.ReadLine());
                var compasso = configMetronomo.TipoCompasso.ToString();

                System.Console.WriteLine("Velocidade: ");
                configMetronomo.Velocidade = int.Parse(System.Console.ReadLine());

                for (int i = 0; i < int.Parse(compasso.Substring(0,1)); i++)
                {
                    Note[] metronomo = { new Note(Tone.A2, Duration.SIXTEENTH) };
                   Play(metronomo);
                }
            }
        }

        private static void ObterEscalaSelecionada(Escala escala)
        {
            switch (escala)
            {
                case Escala.MaiorNatural: ObterEscalaMaiorNatural();
                    break;
                case Escala.MenorNatural: ObterEscalaMenorNatural();
                    break;
                case Escala.MenorMelodica: ObterEscalaMenorMelodica();
                    break;
                case Escala.MenorHarmonica: ObterEscalaMenorHarmonica();
                    break;
                default:
                    break;
            }
        }

        #region Play
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
        #endregion

        #region Escalas
        private static void ObterEscalaMenorHarmonica()
        {
            Note[] escalaSelecionada = { new Note(Tone.C,Duration.QUARTER),
                                 new Note(Tone.D,Duration.QUARTER),
                                 new Note(Tone.Dsharp,Duration.QUARTER),
                                 new Note(Tone.F,Duration.QUARTER),
                                 new Note(Tone.G,Duration.QUARTER),
                                 new Note(Tone.Gsharp,Duration.QUARTER),
                                 new Note(Tone.B2,Duration.QUARTER),
                                 new Note(Tone.C2,Duration.QUARTER)};
            Play(escalaSelecionada);
        }

        private static void ObterEscalaMenorNatural()
        {
            Note[] escalaSelecionada = { new Note(Tone.C,Duration.QUARTER),
                                 new Note(Tone.D,Duration.QUARTER),
                                 new Note(Tone.Dsharp,Duration.QUARTER),
                                 new Note(Tone.F,Duration.QUARTER),
                                 new Note(Tone.G,Duration.QUARTER),
                                 new Note(Tone.Gsharp,Duration.QUARTER),
                                 new Note(Tone.B2,Duration.QUARTER),
                                 new Note(Tone.C2,Duration.QUARTER)};
            Play(escalaSelecionada);
        }

        private static void ObterEscalaMaiorNatural()
        {
            Note[] escalaSelecionada = { new Note(Tone.C,Duration.QUARTER),
                                 new Note(Tone.D,Duration.QUARTER),
                                 new Note(Tone.E,Duration.QUARTER),
                                 new Note(Tone.F,Duration.QUARTER),
                                 new Note(Tone.G,Duration.QUARTER),
                                 new Note(Tone.A2,Duration.QUARTER),
                                 new Note(Tone.B2,Duration.QUARTER),
                                 new Note(Tone.C2,Duration.QUARTER)};
            Play(escalaSelecionada);
        }

        private static void ObterEscalaMenorMelodica()
        {
            Note[] escalaSelecionada = { new Note(Tone.C,Duration.QUARTER),
                                 new Note(Tone.D,Duration.QUARTER),
                                 new Note(Tone.Dsharp,Duration.QUARTER),
                                 new Note(Tone.F,Duration.QUARTER),
                                 new Note(Tone.G,Duration.QUARTER),
                                 new Note(Tone.A2,Duration.QUARTER),
                                 new Note(Tone.B2,Duration.QUARTER),
                                 new Note(Tone.C2,Duration.QUARTER)};
            Play(escalaSelecionada);
        }
        #endregion

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
            Gsharp = 415
        }
        protected enum Duration
        {
            WHOLE = 1600,
            HALF = WHOLE / 2,
            QUARTER = HALF / 2,
            EIGHTH = QUARTER / 2,
            SIXTEENTH = EIGHTH / 2,
            TRINTADOIS = SIXTEENTH / 2
        }

        protected enum Escala
        {
            MaiorNatural = 1,
            MenorNatural = 2,
            MenorMelodica = 3,
            MenorHarmonica = 4,
            PentatonicaMaior = 5,
            PentatonicaMenor = 6,
            PentatonicaMaiorBlues = 7,
            PentatonicaMenorBlues = 8
        }
        #endregion

        public class ConfiguracaoMetronomo
        {
            public int TipoCompasso { get; set; }
            public int Velocidade { get; set; }
        }

    }
    
}
