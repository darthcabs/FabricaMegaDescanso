using Fiap.Projeto.Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fiap.Projeto.Web.MVC.ViewModels
{
    public class PerguntaViewModel
    {

        public ICollection<Pergunta> Perguntas { get; set; }
        public String NomeAluno { get; set; }

        #region Pergunta Properties
        [Display(Name = "RM")]
        public int AlunoRm { get; set; }
        [Display(Name = "Título")]
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Título nulo ou muito grande")]
        public string Titulo { get; set; }
        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }
        [Display(Name = "Tags")]
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Tag nula ou multiplas tags")]
        public string Tag { get; set; }
        [Display(Name = "Data de criação")]
        public System.DateTime Data { get; set; }
        public Nullable<int> RespostaEscolhida { get; set; }
        #endregion

    }
}