using System.Linq;
using Xunit;

namespace BinaryOcean.EFCore5.Tests
{
    public class NavLinkBase : TestBase
    {
        [Fact]
        public void LinkEntities()
        {
            Init(out var player, out var game);

            player.Games.Add(game);

            // Only Player.Games is established.
            // This seems reasonable.

            Assert.Equal(1, player.Games.Count);
            Assert.Equal(0, player.PlayerGames.Count);
            Assert.Equal(0, game.Players.Count);
            Assert.Equal(0, game.PlayerGames.Count);
        }

        [Fact]
        public void AttachToContext()
        {
            Init(out var player, out var game);
            player.Games.Add(game);

            using var context = GetContext();

            // The Player is the "base" of the graph.
            context.Players.Add(player);
            context.SaveChanges();

            Assert.Equal(1, player.Games.Count);
            Assert.Equal(1, player.PlayerGames.Count);

            Assert.Equal(1, game.Players.Count);
            Assert.Equal(1, game.PlayerGames.Count);

            Assert.Equal(1, context.PlayerGames.Count());
        }
    }
}
