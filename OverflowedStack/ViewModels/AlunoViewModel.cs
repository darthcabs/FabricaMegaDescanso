using Fiap.Projeto.Dominio.Models;
using OverflowedStack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OverflowedStack.ViewModels
{
    public class AlunoViewModel
    {

        public ICollection<Aluno> Alunos { get; set; }

        #region Aluno Properties
        [Display(Name = "RM")]
        public int Rm { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        #endregion

    }
}