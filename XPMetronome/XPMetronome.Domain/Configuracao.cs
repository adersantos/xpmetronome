using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPMetronome.Domain
{
    public class Configuracao
    {
        public int TipoCompasso { get; set; }

        public int Velocidade { get; set; }

        public int CompassosRepetir { get; set; }
    }

    #region Enum
    public enum Tone
    {
        REST = 0,
        GbelowC = 196,
        A = 220,
        A0 = A / 2,
        A2 = A * 2,
        Asharp = 233,
        Asharp2 = Asharp * 2,
        B = 247,
        B0 = B / 2,
        B2 = B * 2,
        C = 262,
        C0 = C / 2,
        C2 = C * 2,
        Csharp = 277,
        C0Sharp = Csharp / 2,
        D = 294,
        D0 = D / 2,
        Dsharp = 311,
        D0sharp = Dsharp / 2,
        E = 330,
        E0 = E / 2,
        F = 349,
        F0 = F / 2,
        Fsharp = 370,
        F0sharp = Fsharp / 2,
        G = 392,
        G0 = G / 2,
        Gsharp = 415,
        G0sharp = Gsharp / 2

    }

    public enum Duration
    {
        // 60.000ms/bpm = um beat por milisegundos, ou seja 60.000/100 = 600ms(em 1/4)
        WHOLE = 2400,
        HALF = WHOLE / 2,
        QUARTER = HALF / 2, // 1/4 de WHOLE = 600 em 100BPM
        EIGHTH = QUARTER / 2,
        SIXTEENTH = EIGHTH / 2,
        TRINTADOIS = SIXTEENTH / 2
    }

    public enum Escala
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
}
