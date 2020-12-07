using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BinaryOcean.EFCore5.Library
{
    public static class EntityBaseExtensions
    {
        public static EntityTypeBuilder<T> ConfigureEntityBase<T>(this EntityTypeBuilder<T> builder) where T : EntityBase
        {
            builder
                .Property(e => e.RowVersion)
                .IsRowVersion();

            return builder;
        }
    }
}
