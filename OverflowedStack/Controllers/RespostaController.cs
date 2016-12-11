using Fiap.Projeto.Dominio.Models;
using Fiap.Projeto.Repositories.UnitsOfWork;
using OverflowedStack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OverflowedStack.Controllers
{
    public class RespostaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        #region Get
        [HttpGet]
        public ActionResult Cadastrar(int id, int autor)
        {
            var respostaViewModel = new RespostaViewModel()
            {
                PerguntaId = id,
                Autor = autor
            };

            return View(respostaViewModel);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View();
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Cadastrar(RespostaViewModel respostaViewModel)
        {
            var resposta = new Resposta()
            {               
                Id = 1,
                PerguntaId = respostaViewModel.PerguntaId,
                Autor = respostaViewModel.Autor,
                AlunoRm = 12345,
                Descricao = respostaViewModel.Descricao,
                Data = DateTime.Now
            };

            _unit.RespostaRepository.Cadastrar(resposta);
            _unit.Salvar();

            return RedirectToAction("Cadastrar");
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }
}