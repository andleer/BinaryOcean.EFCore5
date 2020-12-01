using BinaryOcean.EFCore5.Library;
using Xunit;

namespace BinaryOcean.EFCore5.Tests
{
    public class NavLinkBaseToLeaf : TestBase
    {
        public NavLinkBaseToLeaf()
        {
            Context = GetContext();

            Player = new Player { Name = "Andrew", };
            Game = new Game { Name = "Rocket League", };

            // Player.Games => Game
            Player.Games.Add(Game);
        }

        [Fact]
        public void LinkedEntities()
        {
            // Only Player.Games is established.
            Assert.True(Player.Games.Count == 1);
            Assert.True(Player.PlayerGames.Count == 0);
            Assert.True(Game.Players.Count == 0);
            Assert.True(Game.PlayerGames.Count == 0);
        }

        [Fact]
        public void AttachedToContext()
        {
            // The Player is the "base" of the graph.
            Context.Players.Add(Player);

            // After the graph base entity is added to the context,
            // all relationships are established.
            Assert.True(Player.Games.Count == 1);
            Assert.True(Player.PlayerGames.Count == 1);

            Assert.True(Game.Players.Count == 1);
            Assert.True(Game.PlayerGames.Count == 1);
        }
    }
}
