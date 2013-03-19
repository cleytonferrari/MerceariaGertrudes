using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MerceariaDaGertrudes.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string login, string senha)
        {
            if (login == "cleyton" && senha == "171099")
            {
                //autentica ele
                FormsAuthentication.SetAuthCookie(login, false);
                return RedirectToAction("Inicio");
            }

            ViewBag.Mensagem = "Login/Senha invalidos";
            return View();
        }

        [Authorize]
        public ActionResult Inicio()
        {
            return View();
        }

    }
}
