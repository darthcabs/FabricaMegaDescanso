using Fiap.Projeto.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OverflowedStack.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Fields
        private Entidades _context = new Entidades();
        #endregion

        //Properties...

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