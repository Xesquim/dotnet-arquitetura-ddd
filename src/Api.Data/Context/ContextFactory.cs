using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApiContext>
    {
        public ApiContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=.\\SQLEXPRESS2022;Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=localdb123";
            var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseSnakeCaseNamingConvention();
            return new ApiContext(optionsBuilder.Options);
        }
    }
}
