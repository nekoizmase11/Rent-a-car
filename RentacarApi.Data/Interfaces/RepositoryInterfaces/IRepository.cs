
namespace RentacarApi.Data.Interfaces.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        void Remove(T entity);
    }
}
