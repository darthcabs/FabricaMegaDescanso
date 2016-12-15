using Fiap.Projeto.Dominio.Models;
using Fiap.Projeto.Repositories.UnitsOfWork;
using Fiap.Projeto.Web.MVC.ViewModels;
using System;
using System.Web.Mvc;

namespace Fiap.Projeto.Web.MVC.Controllers
{
    [Authorize]
    public class RespostaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();
        private static int _id = 1;

        #region Get
        [HttpGet]
        public ActionResult Cadastrar(int id,int rm)
        {
            var respostaViewModel = new RespostaViewModel()
            {
                PerguntaId = id,
                Autor = rm
            };

            return View(respostaViewModel);
        }

        [HttpGet]
        public ActionResult Listar(int id,int rm)
        {
            var pergunta = _unit.PerguntaRepository.BuscarPorChave(id, rm);

            var respostaViewModel = new RespostaViewModel()
            {
                Respostas = _unit.RespostaRepository.BuscarPor(r => r.PerguntaId == id),
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

            return RedirectToAction("Listar", new { id = respostaViewModel.PerguntaId, rm = respostaViewModel.Autor });
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