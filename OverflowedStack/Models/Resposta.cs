using System;

namespace Fiap.Projeto.Web
{
    public class Resposta
    {
        public int Id { get; set; }
        public Autor Autor { get; set; }
        public string Descricao { get; set; }

        public DateTime Data { get; set; }
    }
}