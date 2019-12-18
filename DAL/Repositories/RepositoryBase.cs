using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly ILogger _logger;
        protected Context Context { get; }

        private RepositoryBase(ILogger logger)
        {
            _logger = logger;
        }

        public RepositoryBase(Context context, ILogger logger) : this(logger)
        {
            Context = context;
        }

        protected DbSet<T> GetDbSet()
        {
            return Context.Set<T>();
        }

        public virtual int Count()
        {
            return GetDbSet().Count();
        }

        public virtual Task<int> CountAsync()
        {
            return GetDbSet().CountAsync();
        }

        public virtual T Read(int entityId)
        {
            return GetDbSet().Find(entityId);
        }

        public virtual Task<T> ReadAsync(int entityId)
        {
            return GetDbSet().FindAsync(entityId).AsTask();
        }

        public virtual IEnumerable<T> ReadAll()
        {
            return GetDbSet().ToArray();
        }

        public virtual Task<IEnumerable<T>> ReadAllAsync()
        {
            return Task.FromResult(ReadAll());
        }

        public virtual void Add(T entity)
        {
            Context.Add(entity);
        }

        public virtual async Task AddAsync(T entity)
        {
            await Context.AddAsync(entity);
        }

        public virtual T Edit(T entity)
        {
            Context.Update(entity);

            // Concurrency token docs : https://docs.microsoft.com/en-us/ef/core/modeling/concurrency#timestamprow-version
            // Context.Entry(entity).OriginalValues["RowVersion"] = entity.RowVersion;

            return entity;
        }

        public virtual void Delete(T entity)
        {
            Context.Remove(entity);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
