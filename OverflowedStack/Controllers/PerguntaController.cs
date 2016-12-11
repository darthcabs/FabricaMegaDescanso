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