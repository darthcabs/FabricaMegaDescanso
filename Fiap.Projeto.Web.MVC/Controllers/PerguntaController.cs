using Fiap.Projeto.Dominio.Models;
using Fiap.Projeto.Repositories.UnitsOfWork;
using Fiap.Projeto.Web.MVC.Models;
using Fiap.Projeto.Web.MVC.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;

namespace Fiap.Projeto.Web.MVC.Controllers
{
    [Authorize]
    public class PerguntaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();
        
        #region Get
        [HttpGet]
        public ActionResult Cadastrar()
        {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var userManager = new UserManager<ApplicationUser>(store);
            ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
            
            var perguntaViewModel = new PerguntaViewModel()
            {
                AlunoRm = user.Rm,
                NomeAluno = user.UserName 
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
            int i = 2;

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