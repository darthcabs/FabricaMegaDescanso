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
        private static int _id = 1;

        #region Get
        [HttpGet]
        public ActionResult Cadastrar(int id,int autor)
        {
            var respostaViewModel = new RespostaViewModel()
            {
                PerguntaId = id,
                Autor = autor
            };

            return View(respostaViewModel);
        }

        [HttpGet]
        public ActionResult Listar(int id,int rm)
        {
            var pergunta = _unit.PerguntaRepository.BuscarPorChave(id, rm);
            var respostaViewModel = new RespostaViewModel()
            {
                Respostas = _unit.RespostaRepository.Listar(),
                Pergunta = pergunta
            };
            return View(respostaViewModel);
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Cadastrar(RespostaViewModel respostaViewModel)
        {
            var resposta = new Resposta()
            {
                Id = _id++,
                PerguntaId = respostaViewModel.PerguntaId,
                Autor = respostaViewModel.Autor,
                AlunoRm = 12345,
                Descricao = respostaViewModel.Descricao,
                Data = DateTime.Now
            };

            _unit.RespostaRepository.Cadastrar(resposta);
            _unit.Salvar();

            return RedirectToAction("Listar");
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