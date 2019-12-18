using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class OrderingContextDesignTimeFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().AddEnvironmentVariables("boilerplate_").Build();
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseSqlServer(config.GetConnectionString("DbContext")); // name of the environment variable beginning with "ConnectionStrings__"

            return new Context(builder.Options);
        }
    }
}
