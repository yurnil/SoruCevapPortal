using System.Linq.Expressions;

namespace SoruCevapPortal.API.Repositories
{
    // T : class diyerek bunun sadece sınıflar (bizim modellerimiz) için çalışacağını belirtiyoruz.
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}