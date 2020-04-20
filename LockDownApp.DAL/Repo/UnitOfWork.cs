using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockDownApp.DAL.Repo.Interface;

namespace LockDownApp.DAL.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        private readonly Dictionary<Type, object> _repositories;

        private bool _disposed = false;

        public UnitOfWork(DbContext context)
        {
            this._context = context;

            _repositories = new Dictionary<Type, object>();
        }


        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories.Keys.Contains(typeof(T)))
                {
                    return _repositories[typeof(T)] as IRepository<T>;
                }

            IRepository<T> repo = new Repository<T>(_context);

            _repositories.Add(typeof(T), repo);

            return repo;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if(_disposed && disposing) _context.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
