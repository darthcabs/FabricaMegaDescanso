using Fiap.Projeto.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Projeto.Repositories.Repositories
{
    public interface IRespostaRepository : IGenericRepository<Resposta>
    {

        Resposta BuscarPorChave(int id, int rm);

    }
}
