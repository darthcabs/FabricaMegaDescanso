using System;

namespace OverflowedStack.Models
{
    public class Resposta
    {
        public int Id { get; set; }
        public Autor Autor { get; set; }
        public string Descricao { get; set; }

        public DateTime Data { get; set; }
    }
}