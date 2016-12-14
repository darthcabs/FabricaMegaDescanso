using Fiap.Projeto.Dominio.Models;
using OverflowedStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Projeto.Repositories.Repositories
{
    public class RespostaRepository : GenericRepository<Resposta>, IRespostaRepository
    {
        public RespostaRepository(Entidades context) : base(context)
        {
        }

        public Resposta BuscarPorChave(int id, int perguntaId)
        {
            return _dbSet.Find(id, perguntaId);
        }
    }
}
