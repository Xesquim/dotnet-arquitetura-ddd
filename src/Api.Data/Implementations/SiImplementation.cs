using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class SiImplementation : BaseRepository<SiEntity>, ISiRepository
    {
        private DbSet<SiEntity> _dataset;

        public SiImplementation(ApiContext context) : base(context)
        {
            _dataset = context.Set<SiEntity>();
        }
    }
}