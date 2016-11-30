using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Projeto.Web
{
    class Pergunta
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public List<string> Tags { get; set; }

        public Resposta RespostaEscolhida { get; set; }

        public List<Resposta> Respostas { get; set; }

        public DateTime DataCriacao { get; set; }
        public Autor Autor { get; set; }

    }
}
