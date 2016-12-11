using Fiap.Projeto.Dominio.Models;
using OverflowedStack.Models;
using Fiap.Projeto.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.Projeto.Repositories.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Fields
        private Entidades _context = new Entidades();

        //Aluno
        private IGenericRepository<Aluno> _alunoRepository;
        #endregion

        #region Properties
        //Aluno
        public IGenericRepository<Aluno> AlunoRepository
        {
            get
            {
                if (_alunoRepository == null)
                {
                    _alunoRepository = new GenericRepository<Aluno>(_context);
                }
                return _alunoRepository;
            }
        }


        #endregion

        #region Save Changes
        public void Salvar()
        {
            _context.SaveChanges();
        }
        #endregion

        #region Dipose
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}