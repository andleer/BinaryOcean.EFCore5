using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BinaryOcean.EFCore5.Library
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .ToTable(nameof(Player))
                .ConfigureEntityBase();

            builder
                .HasMany(e => e.Games)
                .WithMany(e => e.Players)
                .UsingEntity<PlayerGame>
                (
                    e => e.HasOne(k => k.Game).WithMany(k => k.PlayerGames),
                    e => e.HasOne(k => k.Player).WithMany(k => k.PlayerGames)
                );
        }
    }
}
