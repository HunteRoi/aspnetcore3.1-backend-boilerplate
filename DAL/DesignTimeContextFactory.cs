using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace DAL
{
    public class OrderingContextDesignTimeFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().AddEnvironmentVariables("boilerplate_").Build();
            var builder = new DbContextOptionsBuilder<Context>();
            
            string connectionstring = config.GetConnectionString("DbContext") ?? throw new ArgumentNullException("You must add a environment variable named 'boilerplate_ConnectionStrings__Dbcontext' !");
            builder.UseSqlServer(connectionstring);

            return new Context(builder.Options);
        }
    }
}
