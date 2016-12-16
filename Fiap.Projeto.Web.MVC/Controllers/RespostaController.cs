using Fiap.Projeto.Dominio.Models;
using Fiap.Projeto.Persistencia.UnitsOfWork;
using Fiap.Projeto.Web.MVC.Models;
using Fiap.Projeto.Web.MVC.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;

namespace Fiap.Projeto.Web.MVC.Controllers
{
    [Authorize]
    public class RespostaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        #region Get
        [HttpGet]
        public ActionResult Cadastrar(int id,int rm)
        {
            ApplicationUser user = GetLoggedUser();

            var respostaViewModel = new RespostaViewModel()
            {
                PerguntaId = id,
                Autor = rm
            };

            return View(respostaViewModel);
        }

        private ApplicationUser GetLoggedUser()
        {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var userManager = new UserManager<ApplicationUser>(store);
            ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

            return user;
        }

        [HttpGet]
        public ActionResult Listar(int id,int rm)
        {
            ApplicationUser user = GetLoggedUser();

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
            ApplicationUser user = GetLoggedUser();

            var resposta = new Resposta()
            {
                PerguntaId = respostaViewModel.PerguntaId,
                Autor = respostaViewModel.Autor,
                AlunoRm = user.Rm,
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