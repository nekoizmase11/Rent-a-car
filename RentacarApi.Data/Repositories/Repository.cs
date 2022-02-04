using Microsoft.EntityFrameworkCore;
using RentacarApi.Data.Interfaces.RepositoryInterfaces;

namespace RentacarApi.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            var result = _context.Set<T>().Add(entity);
            return result.Entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
