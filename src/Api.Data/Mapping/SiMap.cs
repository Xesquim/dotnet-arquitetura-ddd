using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class SiMap : IEntityTypeConfiguration<SiEntity>
    {
        public void Configure(EntityTypeBuilder<SiEntity> builder)
        {
            builder.ToTable("si");

            builder.HasKey(column => column.Id);

            builder.HasIndex(column => column.Abbreviation)
                    .IsUnique();
        }
    }
}