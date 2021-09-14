using DDD_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD_Data.Mapping
{
    public class PostalCodeMap : IEntityTypeConfiguration<PostalCodeEntity>
    {
        public void Configure(EntityTypeBuilder<PostalCodeEntity> builder)
        {
            builder.ToTable("PostalCode");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.PostalCode);

            builder.HasOne(u => u.City)
                .WithMany(m => m.PostalCodes);
        }
    }
}