using Fiap.Projeto.Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fiap.Projeto.Web.MVC.ViewModels
{
    public class AlunoViewModel
    {

        public ICollection<Aluno> Alunos { get; set; }

        #region Aluno Properties
        [Display(Name = "RM")]
        [Required]
        [Range(5, 5, ErrorMessage = "RM inválido")]
        public int Rm { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 8, ErrorMessage ="Senha inválida!")]
        public string Senha { get; set; }
        #endregion

    }
}