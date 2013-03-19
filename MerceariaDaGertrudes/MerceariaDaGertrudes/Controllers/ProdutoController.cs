using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MerceariaDaGertrudes.Aplicacao;
using MerceariaDaGertrudes.Models;

namespace MerceariaDaGertrudes.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        public ActionResult Index()
        {
            var produtoAplicacao = new ProdutoAplicacao();
            return View(produtoAplicacao.ListarTodos());
        }

        public ActionResult Detalhes(int id)
        {
            var produtoAplicao = new ProdutoAplicacao();
            var produto = produtoAplicao.ListarPorId(id);
            if (produto == null)
                return HttpNotFound();
            return View(produto);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var produtoAplicacao = new ProdutoAplicacao();
                produtoAplicacao.Salvar(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Editar(int id)
        {
            var produtoAplicacao = new ProdutoAplicacao();
            var produto = produtoAplicacao.ListarPorId(id);
            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        [HttpPost]
        public ActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var produtoAplicacao = new ProdutoAplicacao();
                produtoAplicacao.Salvar(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        public ActionResult Excluir(int id)
        {
            var produtoAplicacao = new ProdutoAplicacao();
            var produto = produtoAplicacao.ListarPorId(id);
            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        [HttpPost,ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var produtoAplicacao = new ProdutoAplicacao();
            produtoAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
