using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MerceariaDaGertrudes.Aplicacao;

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
            var acessoAplicacao = new AcessoAplicacao();
            if (acessoAplicacao.Logar(login, senha))
            {
                //autentica ele
                FormsAuthentication.SetAuthCookie(login, false);
                return RedirectToAction("Inicio");
            }

            ViewBag.Mensagem = "Login/Senha invalidos";
            return View();
        }

        [Authorize]//não precisa se estiver usando no controller
        public ActionResult Inicio()
        {
            return View();
        }

    }
}
