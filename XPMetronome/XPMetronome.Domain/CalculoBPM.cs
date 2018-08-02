using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPMetronome.Domain
{
    public static class CalculoBPM
    {
        

        public static int CalcularBPM(int bpm)
        {
            var retorno = Constants.milisegundos / bpm;

            return retorno;
        }
    }
}
