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

        //Pergunta
        private IGenericRepository<Pergunta> _perguntaRepository;

        //resposta
        private IGenericRepository<Resposta> _respostaRepository;
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

        //Pergunta
        public IGenericRepository<Pergunta>  PerguntaRepository
        {
            get
            {
                if (_perguntaRepository == null)
                {
                    _perguntaRepository = new GenericRepository<Pergunta>(_context);
                }
                return _perguntaRepository;
            }            
        }


        //Resposta
        public IGenericRepository<Resposta> RespostaRepository
        {
            get
            {
                if(_respostaRepository == null)
                {
                    _respostaRepository = new GenericRepository<Resposta>(_context);
                }
                return _respostaRepository;
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