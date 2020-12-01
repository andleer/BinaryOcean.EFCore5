using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BinaryOcean.EFCore5.Library
{
    public static class EntityBaseExtensions
    {
        public static EntityTypeBuilder<T> ConfigureEntityBase<T>(this EntityTypeBuilder<T> builder) where T : EntityBase
        {
            builder
                .Property(e => e.CreatedDateTime)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            builder
                .Property(e => e.RowVersion)
                .IsRowVersion();

            return builder;
        }
    }
}
