using Microsoft.EntityFrameworkCore;
using System;

namespace AwesomeNetwork.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;
        protected readonly DbSet<T> Set;



        public Repository(ApplicationDbContext db)
        {
            _db = db;
            Set = _db.Set<T>();
        }

        public void Create(T item)
        {
            Set.Add(item);
            _db.SaveChanges();
        }

        public void Delete(T item)
        {
            Set.Remove(item);
            _db.SaveChanges();
        }

        public T Get(int id)
        {
            return Set.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Set;
        }

        public void Update(T item)
        {
            Set.Update(item);
            _db.SaveChanges();
        }

    }
}
