using Fiap.Projeto.Dominio.Models;
using OverflowedStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Projeto.Repositories.Repositories
{
    public class PerguntaRepository: GenericRepository<Pergunta>,IPerguntaRepository 
    {
        public PerguntaRepository(Entidades context):base(context)
        {
        }

        public virtual Pergunta BuscarPorChave(int id,int rm)
        {
            return _dbSet.Find(id,rm);
        }

    }
}
