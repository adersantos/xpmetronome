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
            var configMetronomo = new Configuracao();
            string escalaMetronomo = string.Empty;

            System.Console.WriteLine("Escala ou Metronomo: (E/M)");
            escalaMetronomo = System.Console.ReadLine();

            if (escalaMetronomo.ToUpper() == "E")
            {
                Escala escalaSelecionada = (Escala)Enum.Parse(typeof(Escala), ObterEscalaSelecionadaPeloUsuario());

                System.Console.WriteLine("Escolha quantidade de repetições: ");
                int repeticoesTocarEscala = int.Parse(System.Console.ReadLine());

                for (int i = 0; i < repeticoesTocarEscala; i++)
                {
                    ExecutarEscalaSelecionada(escalaSelecionada);
                }
            }
            else
            {
                configMetronomo.TipoCompasso = ObterTipoCompasso();
                configMetronomo.Velocidade = ObterVelocidadeBpm();
                configMetronomo.CompassosRepetir = ObterQtdCompassosRepetir();
                var compassosEvoluir = ObterCompassosEvoluir(configMetronomo.CompassosRepetir);
                int incremento = ObterIncrementoBpm(configMetronomo.Velocidade);

                //ExecutarLoopingInfinito(configMetronomo, compassosEvoluir, incremento);

                for (int i = 0; i < configMetronomo.CompassosRepetir; i++)
                {
                    for (int j = 0; j < configMetronomo.TipoCompasso; j++) //Duration.QUARTER = 600ms => Duration.WHOLE = 2400ms
                    {
                        //Note[] metronomo = { new Note(j == 0 ? Tone.A2 : Tone.C2, i >= compassosEvoluir ? Duration.QUARTER - incremento : Duration.QUARTER) };
                        //Play(metronomo);
                        ExecutarBeep(j, configMetronomo.TipoCompasso, i >= compassosEvoluir ? incremento : configMetronomo.Velocidade);
                    }
                }
            }
        }

        private static void ExecutarLoopingInfinito(Configuracao configMetronomo, int compassosEvoluir, int incremento)
        {
            int i = 0;
            while (i <= 10)
            {
                for (int j = 0; j < configMetronomo.TipoCompasso; j++)
                {
                    ExecutarBeep(j, configMetronomo.TipoCompasso, j >= compassosEvoluir ? incremento : configMetronomo.Velocidade);
                }

                i++;
            }
        }


        #region MétodosEscalas

        #endregion

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

        private static void ExecutarBeep(int contador, int tipoCompasso, int velocidade)
        {
            var compasso = int.Parse(tipoCompasso.ToString().PadRight(1));
            System.Console.Beep(contador == 0 ? (int)Tone.D : (int)Tone.A, velocidade);

        }
        #endregion

        #region Escalas
        private static string ObterEscalaSelecionadaPeloUsuario()
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

            return System.Console.ReadLine();
        }

        private static void ExecutarEscalaSelecionada(Escala escala)
        {
            switch (escala)
            {
                case Escala.MaiorNatural:
                    ObterEscalaMaiorNatural();
                    break;
                case Escala.MenorNatural:
                    ObterEscalaMenorNatural();
                    break;
                case Escala.MenorMelodica:
                    ObterEscalaMenorMelodica();
                    break;
                case Escala.MenorHarmonica:
                    ObterEscalaMenorHarmonica();
                    break;
                default:
                    break;
            }
        }

        private static void ObterEscalaMenorHarmonica()
        {
            Note[] escalaSelecionada = { new Note(Tone.C,Duration.QUARTER),
                                         new Note(Tone.D,Duration.QUARTER),
                                         new Note(Tone.Dsharp,Duration.QUARTER),
                                         new Note(Tone.F,Duration.QUARTER),
                                         new Note(Tone.Gsharp,Duration.QUARTER),
                                         new Note(Tone.A2,Duration.QUARTER),
                                         new Note(Tone.B2,Duration.QUARTER),
                                         new Note(Tone.C2,Duration.QUARTER),
                                         new Note(Tone.C2,Duration.QUARTER),
                                         new Note(Tone.B2,Duration.QUARTER),
                                         new Note(Tone.A2,Duration.QUARTER),
                                         new Note(Tone.Gsharp,Duration.QUARTER),
                                         new Note(Tone.F,Duration.QUARTER),
                                         new Note(Tone.Dsharp,Duration.QUARTER),
                                         new Note(Tone.D,Duration.QUARTER),
                                         new Note(Tone.C,Duration.QUARTER)};
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
                                         new Note(Tone.Asharp2,Duration.QUARTER),
                                         new Note(Tone.C2,Duration.QUARTER),
                                         new Note(Tone.C2,Duration.QUARTER),
                                         new Note(Tone.Asharp2,Duration.QUARTER),
                                         new Note(Tone.A2,Duration.QUARTER),
                                         new Note(Tone.Gsharp,Duration.QUARTER),
                                         new Note(Tone.F,Duration.QUARTER),
                                         new Note(Tone.Dsharp,Duration.QUARTER),
                                         new Note(Tone.D,Duration.QUARTER),
                                         new Note(Tone.C,Duration.QUARTER)};
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
                                         new Note(Tone.C2,Duration.QUARTER),
                                         new Note(Tone.C2,Duration.QUARTER),
                                         new Note(Tone.B2,Duration.QUARTER),
                                         new Note(Tone.A2,Duration.QUARTER),
                                         new Note(Tone.G,Duration.QUARTER),
                                         new Note(Tone.F,Duration.QUARTER),
                                         new Note(Tone.E,Duration.QUARTER),
                                         new Note(Tone.D,Duration.QUARTER),
                                         new Note(Tone.C,Duration.QUARTER)};
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
                                         new Note(Tone.C2,Duration.QUARTER),
                                         new Note(Tone.C2,Duration.QUARTER),
                                         new Note(Tone.B2,Duration.QUARTER),
                                         new Note(Tone.A2,Duration.QUARTER),
                                         new Note(Tone.G,Duration.QUARTER),
                                         new Note(Tone.F,Duration.QUARTER),
                                         new Note(Tone.Dsharp,Duration.QUARTER),
                                         new Note(Tone.D,Duration.QUARTER),
                                         new Note(Tone.C,Duration.QUARTER)};
            Play(escalaSelecionada);
        }
        #endregion

        #region Metronomo
        private static int ObterVelocidadeBpm()
        {
            System.Console.WriteLine("Velocidade: (bpm)");
            return CalculoBPM.CalcularBPM(int.Parse(System.Console.ReadLine()));
        }

        private static int ObterTipoCompasso()
        {
            System.Console.WriteLine("Tipo Compasso: ");
            return int.Parse(System.Console.ReadLine().Substring(0, 1));
        }

        private static int ObterQtdCompassosRepetir()
        {
            System.Console.WriteLine("Informe quantidade de compassos a repetir: ");
            return int.Parse(System.Console.ReadLine());
        }

        private static int ObterCompassosEvoluir(int compassosRepetir)
        {
            int evoluir = 0;
            System.Console.WriteLine("A partir de qual compasso deseja aumentar a velocidade?: ");

            evoluir = int.Parse(System.Console.ReadLine().Substring(0, 1));
            if (compassosRepetir < evoluir)
            {
                while (compassosRepetir < evoluir)
                {
                    System.Console.WriteLine("Os compassos a evoluir não podem ser maiores que o total de compassos: ");
                    evoluir = int.Parse(System.Console.ReadLine().Substring(0, 1));
                }
            }

            return evoluir;
        }

        private static int ObterIncrementoBpm(int bpmAnterior)
        {
            System.Console.WriteLine("Quantos BPM's deseja incrementar?: ");
            var bpmAtual = CalculoBPM.CalcularBPM(Constants.milisegundos / bpmAnterior + int.Parse(System.Console.ReadLine()));
            return bpmAtual;
        }
        #endregion

    }

}
