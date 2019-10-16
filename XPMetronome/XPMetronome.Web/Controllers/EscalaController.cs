using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XPMetronome.Web.Controllers
{
    public class EscalaController : Controller
    {
        // GET: Escala
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MontarEscala()
        {
            ViewBag.Message = "Metrônomo Inteligente.";

            return View();
        }
    }
}