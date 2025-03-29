using AwesomeNetwork.Data.Repository;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace AwesomeNetwork.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _appContext;
 
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        public UnitOfWork(ApplicationDbContext app)
        {
            _appContext = app;
         
        }
        public void Dispose()
        {

        }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class
        {
            if (_repositories.TryGetValue(typeof(TEntity), out var repository))
            {
                return (IRepository<TEntity>)repository;
            }

            if (hasCustomRepository)
            {
         
                var customRepository = _appContext.GetService<IRepository<TEntity>>();
                if (customRepository != null)
                {
                   _repositories[typeof(TEntity)] = customRepository;
                    return customRepository;
                }
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_appContext);
            }

            return (IRepository<TEntity>)_repositories[type];

        }
        public int SaveChanges(bool ensureAutoHistory = false)
        {
            throw new NotImplementedException();
        }
    }
}
