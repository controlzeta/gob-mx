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
            Models.MailModels mail = new Models.MailModels();
            ViewBag.Message = "Bienvenido a nuestra implementación de Gob Mx.";

            return View(mail);
        }

        public ActionResult EnviarNotificacion(Models.MailModels mail)
        {
            ViewBag.Message = mail.SendMail("Has sido seleccionado ", "Has ganado felicidades!!!", true, "http://www.x1mexico.com", "Recoge tu Premio");
            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Bienvenido a nuestra implementación de Gob Mx.";

            return View();
        }
    }
}
