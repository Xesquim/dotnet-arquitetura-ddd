using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CityImplementation : BaseRepository<CityEntity>, ICityRepository
    {
        private DbSet<CityEntity> _dataset;

        public CityImplementation(ApiContext context) : base(context)
        {
            _dataset = context.Set<CityEntity>();
        }

        public async Task<CityEntity> GetCompleteByIbge(int ibgeCode)
        {
            return await _dataset.Include(c => c.Si)
                                .FirstOrDefaultAsync(c => c.IbgeCode.Equals(ibgeCode));
        }

        public async Task<CityEntity> GetCompleteById(Guid id)
        {
            return await _dataset.Include(c => c.Si)
                                .FirstOrDefaultAsync(c => c.Id.Equals(id));
        }
    }
}