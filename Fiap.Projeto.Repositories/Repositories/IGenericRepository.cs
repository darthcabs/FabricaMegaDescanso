﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Projeto.Persistencia.Repositories
{
    public interface IGenericRepository<T>
    {

        void Cadastrar(T entidade);
        void Alterar(T entidade);
        void Remover(int id);
        ICollection<T> Listar();
        T BuscarPorId(int id);
        T BuscarPorChave(int id, int rm);
        ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro);
    }
}
