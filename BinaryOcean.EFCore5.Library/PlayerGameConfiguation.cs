using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace BinaryOcean.EFCore5.Library
{
    public class PlayerGameConfiguation : IEntityTypeConfiguration<PlayerGame>
    {
        public void Configure(EntityTypeBuilder<PlayerGame> builder)
        {
            builder
                .ToTable(nameof(PlayerGame))
                .ConfigureEntityBase()
                .HasCheckConstraint($"{PlayerRoleColumnName}_Constraint", $"{GetPlayerRoleConstraint()}");

            builder.HasKey(k => new { k.GameId, k.PlayerId, });

            builder
                .Property(p => p.PlayerRole)
                .HasColumnName(PlayerRoleColumnName)
                .HasConversion(e => (int)e, i => (PlayerRole)i)
                ;
        }

        private static string PlayerRoleColumnName => $"{nameof(PlayerGame.PlayerRole)}ID";

        private static string GetPlayerRoleConstraint()
        {
            var values = Enum.GetValues<PlayerRole>().Select(i => $"[{PlayerRoleColumnName}]={(int)i}");
            return string.Join(" OR ", values);
        }
    }
}
