using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Extensions;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.V1;

namespace DAL.Repositories
{
    public class PersonRepository : RepositoryBase<Person>
    {
        public PersonRepository(Context context, ILogger<PersonRepository> logger) : base(context, logger)
        { }

        protected new DbSet<Person> GetDbSet()
        {
            return Context.People;
        }

        public new Person Read(int entityId)
        {
            return GetDbSet().FirstOrDefault(p => p.Id == entityId);
        }

        public new Task<Person> ReadAsync(int entityId)
        {
            return GetDbSet().FirstOrDefaultAsync(p => p.Id == entityId);
        }

        public Task<IEnumerable<Person>> ReadAllWithFilterAsync(string filter = null, int pageIndex = Constants.PageIndex, int pageSize = Constants.PageSize)
        {
            bool hasFilter = !String.IsNullOrWhiteSpace(filter);
            if (hasFilter)
                filter = filter.ToLower();

            return Task.FromResult(GetDbSet()
                .Where(p => !hasFilter
                    || p.FirstName.ToLower().Contains(filter)
                    || p.LastName.ToLower().Contains(filter)
                    || p.Email.ToLower().Contains(filter))
                .OrderBy(p => p.Id)
                .TakePage(pageIndex, pageSize)
                .AsEnumerable());
        }
    }
}
