using Fiap.Projeto.Dominio.Models;
using Fiap.Projeto.Repositories.UnitsOfWork;
using Fiap.Projeto.Web.MVC.ViewModels;
using System;
using System.Web.Mvc;

namespace Fiap.Projeto.Web.MVC.Controllers
{
    [Authorize]
    public class PerguntaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        private static int _id = 1;
        
        #region Get
        [HttpGet]
        public ActionResult Cadastrar(int rm)
        {
            var aluno = _unit.AlunoRepository.BuscarPorId(rm);
            var perguntaViewModel = new PerguntaViewModel()
            {
                AlunoRm = rm,
                NomeAluno = aluno.Nome 
            };

            return View(perguntaViewModel);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var perguntaViewModel = new PerguntaViewModel()
            {
                Perguntas = _unit.PerguntaRepository.Listar()
            };
            return View(perguntaViewModel);
        }

        public ActionResult Alterar(int perguntaId)
        {
            var pergunta = _unit.PerguntaRepository.BuscarPorId(perguntaId);
            var autor = _unit.AlunoRepository.BuscarPorId(pergunta.AlunoRm);

            var viewModel = new PerguntaViewModel()
            {
                AlunoRm = pergunta.AlunoRm,
                Titulo = pergunta.Titulo,
                Descricao = pergunta.Descricao,
                Data = pergunta.Data,
                Tag = pergunta.Tag,
                NomeAluno = autor.Nome
            };

            return View(viewModel);
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Cadastrar(PerguntaViewModel perguntaViewModel)
        {
            var pergunta = new Pergunta()
            {
                Id = _id++,
                AlunoRm = perguntaViewModel.AlunoRm,
                Titulo = perguntaViewModel.Titulo,
                Descricao = perguntaViewModel.Descricao,
                Data = DateTime.Now,
                Tag = perguntaViewModel.Tag
            };

            _unit.PerguntaRepository.Cadastrar(pergunta);
            _unit.Salvar();

            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Alterar(Pergunta pergForm)
        {
            

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