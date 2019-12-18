using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        int Count();

        Task<int> CountAsync();

        T Read(int entityId);

        Task<T> ReadAsync(int entityId);

        IEnumerable<T> ReadAll();

        Task<IEnumerable<T>> ReadAllAsync();

        void Add(T entity);

        Task AddAsync(T entity);

        T Edit(T entity);

        void Delete(T entity);

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

