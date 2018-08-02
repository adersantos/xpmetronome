using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XPMetronome.Domain;

namespace XPMetronome.Web.Controllers
{
    public class MetronomoController : Controller
    {
        Configuracao configMetronomo = new Configuracao();
        string escalaMetronomo = string.Empty;
        
        public ActionResult Index()
        {
            return View();
        }

        public void ConfigurarMetronomo()
        {
            configMetronomo.TipoCompasso = ObterTipoCompasso();
            configMetronomo.Velocidade = ObterVelocidadeBpm();
            configMetronomo.CompassosRepetir = ObterQtdCompassosRepetir();
            var compassosEvoluir = ObterCompassosEvoluir(configMetronomo.CompassosRepetir);
            int incremento = ObterIncrementoBpm(configMetronomo.Velocidade);

            ExecutarLoopingInfinito(configMetronomo, (int)compassosEvoluir, incremento);

        }

        private void ExecutarLoopingInfinito(Configuracao configMetronomo, int compassosEvoluir, int incremento)
        {
            int i = 0;
            while (i <= 100)
            {
                for (int j = 0; j < configMetronomo.TipoCompasso; j++)
                {
                    ExecutarBeep(j, configMetronomo.TipoCompasso, j >= compassosEvoluir ? incremento : configMetronomo.Velocidade);
                }

                i++;
            }
        }

        private void ExecutarBeep(int contador, int tipoCompasso, int velocidade)
        {
            var compasso = int.Parse(tipoCompasso.ToString().PadRight(1));
            System.Console.Beep(contador == 0 ? (int)Tone.D : (int)Tone.A, velocidade);
        }

        private int ObterIncrementoBpm(int velocidade)
        {
            System.Console.WriteLine("Quantos BPM's deseja incrementar?: ");
            var bpmAtual = CalculoBPM.CalcularBPM(Constants.milisegundos / bpmAnterior + int.Parse(System.Console.ReadLine()));
            return bpmAtual;
        }

        private object ObterCompassosEvoluir(int compassosRepetir)
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

        private int ObterQtdCompassosRepetir()
        {
            System.Console.WriteLine("Informe quantidade de compassos a repetir: ");
            return int.Parse(System.Console.ReadLine());
        }

        private int ObterVelocidadeBpm()
        {
            System.Console.WriteLine("Velocidade: (bpm)");
            return CalculoBPM.CalcularBPM(int.Parse(System.Console.ReadLine()));
        }

        private int ObterTipoCompasso()
        {
            System.Console.WriteLine("Tipo Compasso: ");
            return int.Parse(System.Console.ReadLine().Substring(0, 1));
        }
    }
}