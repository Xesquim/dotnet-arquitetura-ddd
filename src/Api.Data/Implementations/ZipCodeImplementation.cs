using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ZipCodeImplementation : BaseRepository<ZipCodeEntity>, IZipCodeRepository
    {
        private DbSet<ZipCodeEntity> _dataset;

        public ZipCodeImplementation(ApiContext context) : base(context)
        {
            _dataset = context.Set<ZipCodeEntity>();
        }

        public async Task<ZipCodeEntity> SelectAsync(string zipCode)
        {
            return await _dataset.Include(z => z.City)
                                .ThenInclude(c => c.Si)
                                .FirstOrDefaultAsync(z => z.ZipCode.Equals(zipCode));
        }
    }
}