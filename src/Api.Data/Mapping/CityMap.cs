using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CityMap : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.ToTable("city");

            builder.HasKey(column => column.Id);

            builder.HasIndex(column => column.IbgeCode);

            builder.HasOne(column => column.Si)
                    .WithMany(column => column.Cities);
        }
    }
}