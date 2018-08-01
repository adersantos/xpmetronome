using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPMetronome.Domain
{
    public class Compasso
    {
        public Tipo Tipo { get; set; }

        public int Batidas { get; set; }

        public int Figura { get; set; }

        public Compasso(int _tipo)
        {
            switch (_tipo)
            {
                case 24: Tipo = Tipo.DoisPorQuatro;
                    break;
                case 34: Tipo = Tipo.TreisPorQuatro;
                    break;
                case 44: Tipo = Tipo.QuatroPorQuatro;
                    break;
                case 68: Tipo = Tipo.SeisPorOito;
                    break;
                case 74: Tipo = Tipo.SetePorQuatro;
                    break;
                case 78: Tipo = Tipo.SetePorOito;
                    break;
            }
        }
    }

    public enum Tipo
    {
        DoisPorQuatro = 24,
        TreisPorQuatro = 34,
        QuatroPorQuatro = 44,
        SetePorQuatro = 74,
        SeisPorOito = 68,
        SetePorOito = 78
    }
}
