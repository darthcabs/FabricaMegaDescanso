using Fiap.Projeto.Dominio.Models;
using System.Web.Mvc;
using Fiap.Projeto.Repositories.UnitsOfWork;
using Fiap.Projeto.Web.MVC.ViewModels;

namespace Fiap.Projeto.Web.MVC.Controllers
{
    [Authorize]
    public class AlunoController : Controller
    {

        private UnitOfWork _unit = new UnitOfWork();

        #region Get
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var alunoViewModel = new AlunoViewModel()
            {
                Alunos = _unit.AlunoRepository.Listar()
            };
            return View(alunoViewModel);
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Cadastrar(AlunoViewModel alunoViewModel)
        {
            var aluno = new Aluno()
            {
                Rm = alunoViewModel.Rm,
                Nome = alunoViewModel.Nome,
                Senha = alunoViewModel.Senha
            };
            _unit.AlunoRepository.Cadastrar(aluno);
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