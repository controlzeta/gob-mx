using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GobMxDummy.Controllers
{
    public class HomeController : Controller
    {
        //Log4Net log
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController).FullName);

        public ActionResult GenerateDebugLog()
        {
            log.Info("Starting GenerateDebugLog method...");
            log.Debug("No input parameters for method.");

            log.Info("Starting loop.");
            for (var i = 0; i <= 10; i++)
            {
                log.Debug("Current value: " + i);
            }
            log.Info("Loop complete.");

            log.Info("GenerateDebugLog method complete.");

            try
            {
                throw new Exception("Evil exception test!");
            }
            catch (Exception ex)
            {
                log.Error("Bad Juice!", ex);
            }

            ViewBag.Message = "Sample complete.";
            return View("About");
        }

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
