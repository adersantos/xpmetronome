using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using XPMetronome.Domain;
using XPMetronome.Web.Models;

namespace XPMetronome.Web.Controllers
{
    public class MetronomoController : Controller
    {
        Configuracao configMetronomo = new Configuracao();
        string escalaMetronomo = string.Empty;
        
        public ActionResult Metronomo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExecutarMetronomo(MetronomoModel model)
        {
            string retorno = "Executando";
            var mensagens = new List<string>();

            if (!ModelState.IsValid)
            {
                retorno = "Model state inválida.";
                mensagens = ModelState.Values.SelectMany(m => m.Errors).Select(n => n.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    ExecutarLoopingInfinito(model);
                }
                catch (Exception)
                {
                    retorno = "throw";
                }
            }
            return Json(new { Retorno = retorno, Mensagens = mensagens});
        }

        private void ExecutarLoopingInfinito(MetronomoModel model)
        {
            int i = 0;
            int tipoCompasso = int.Parse(model.TipoCompasso.Substring(0, 1));
            int bpmOriginal = CalculoBPM.CalcularBPM(model.Bpm);
            int bpmAtual = CalculoBPM.CalcularBPM(Constants.milisegundos / (model.IncrementoBpm + model.Bpm));

            while (i <= 10)
            {
                for (int j = 0; j <= tipoCompasso; j++)
                {
                    ExecutarBeep(j, tipoCompasso, j >= model.QtdCompassosEvoluir ? bpmAtual : bpmOriginal);
                }

                i++;
            }
        }

        private void ExecutarBeep(int contador, int tipoCompasso, int velocidade)
        {
            Thread.Sleep(500);
            System.Console.Beep(contador == 0 ? (int)Tone.D : (int)Tone.A, velocidade);
        }

    }
}