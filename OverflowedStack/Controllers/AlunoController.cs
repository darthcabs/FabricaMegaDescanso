﻿using Fiap.Projeto.Dominio.Models;
using OverflowedStack.Models;
using Fiap.Projeto.Repositories;
using OverflowedStack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fiap.Projeto.Repositories.UnitsOfWork;

namespace OverflowedStack.Controllers
{
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