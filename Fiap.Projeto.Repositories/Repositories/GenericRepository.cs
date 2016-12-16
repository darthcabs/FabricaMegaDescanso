using Fiap.Projeto.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Fiap.Projeto.Persistencia.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected Entidades _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(Entidades context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual void Alterar(T entidade)
        {
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual ICollection<T> BuscarPor(System.Linq.Expressions.Expression<Func<T, bool>> filtro)
        {
            return _dbSet.Where(filtro).ToList();
        }

        public virtual T BuscarPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual T BuscarPorChave(int id, int rm)
        {
            return _dbSet.Find(id, rm);
        }

        public virtual void Cadastrar(T entidade)
        {
            _dbSet.Add(entidade);
        }

        public virtual ICollection<T> Listar()
        {
            return _dbSet.ToList();
        }

        public virtual void Remover(int id)
        {
            var entidade = BuscarPorId(id);
            _dbSet.Remove(entidade);
        }
    }
}