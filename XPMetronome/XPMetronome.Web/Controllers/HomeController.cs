using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XPMetronome.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.Message = "Metrônomo Inteligente.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "By: Ader Santos";

            return View();
        }
    }
}