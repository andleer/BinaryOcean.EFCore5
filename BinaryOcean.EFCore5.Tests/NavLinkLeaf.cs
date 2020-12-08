using System.Linq;
using Xunit;

namespace BinaryOcean.EFCore5.Tests
{
    public class NavLinkLeaf : TestBase
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

            // The Game is the "leaf" of the graph.
            context.Games.Add(game);
            context.SaveChanges();

            Assert.Equal(1, player.Games.Count);
            Assert.Equal(1, player.PlayerGames.Count); 

            Assert.Equal(1, game.Players.Count);  
            Assert.Equal(1, game.PlayerGames.Count);  

            Assert.Equal(1, context.PlayerGames.Count());
        }
    }
}
