using Fiap.Projeto.Repositories.UnitsOfWork;
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
        public ActionResult Cadastrar(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View();
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Cadastrar()
        {
            return View();
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