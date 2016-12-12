using Fiap.Projeto.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OverflowedStack.ViewModels
{
    public class RespostaViewModel
    {
        public Pergunta Pergunta { get; set; }
        public ICollection<Resposta> Respostas { get; set; }
        public string NomeAluno { get; set; }

        #region Resposta Properties

        public int PerguntaId { get; set; }
        public int Autor { get; set; }
        public int AlunoRm { get; set; }
        public string Descricao { get; set; }
        public System.DateTime Data { get; set; }

        #endregion
    }
}