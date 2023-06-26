using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTest : IDisposable
    {
        private string dataBaseName = $"dbApiTest {Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<ApiContext>(o =>
                o.UseSqlServer($"Server=.\\SQLEXPRESS2022;Initial Catalog={dataBaseName};MultipleActiveResultSets=true;User ID=sa;Password=localdb123"),
                ServiceLifetime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<ApiContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<ApiContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}