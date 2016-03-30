using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GobMxDummy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Bienvenido a nuestra implementación de Gob Mx.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bienvenido a nuestra implementación de Gob Mx.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Bienvenido a nuestra implementación de Gob Mx.";

            return View();
        }
    }
}
