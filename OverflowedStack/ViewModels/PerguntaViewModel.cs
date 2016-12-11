using Fiap.Projeto.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OverflowedStack.ViewModels
{
    public class PerguntaViewModel
    {

        public ICollection<Pergunta> Perguntas { get; set; }

        #region Pergunta Properties
        public int AlunoRm { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Tag { get; set; }
        public System.DateTime Data { get; set; }
        public Nullable<int> RespostaEscolhida { get; set; }
        #endregion

    }
}