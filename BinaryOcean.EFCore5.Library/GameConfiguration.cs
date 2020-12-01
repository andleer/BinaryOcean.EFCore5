using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BinaryOcean.EFCore5.Library
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .ToTable(nameof(Game))
                .ConfigureEntityBase();

            builder
                .HasMany(e => e.Players)
                .WithMany(e => e.Games)
                .UsingEntity<PlayerGame>
                (
                    e => e.HasOne(k => k.Player).WithMany(k => k.PlayerGames),
                    e => e.HasOne(k => k.Game).WithMany(k => k.PlayerGames)
                );
        }
    }
}