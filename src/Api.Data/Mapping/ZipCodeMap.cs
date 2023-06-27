using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ZipCodeMap : IEntityTypeConfiguration<ZipCodeEntity>
    {
        public void Configure(EntityTypeBuilder<ZipCodeEntity> builder)
        {
            builder.ToTable("zip_code");

            builder.HasKey(column => column.Id);

            builder.HasIndex(column => column.ZipCode);

            builder.HasOne(column => column.City)
                    .WithMany(column => column.ZipCodes);
        }
    }
}