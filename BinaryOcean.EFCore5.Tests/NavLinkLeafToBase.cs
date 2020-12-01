using BinaryOcean.EFCore5.Library;
using Xunit;

namespace BinaryOcean.EFCore5.Tests
{
    public class NavLinkLeafToBase : TestBase
    {
        public NavLinkLeafToBase()
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
            // The Game is the "leaf" of the graph.
            Context.Games.Add(Game);

            // After the leaf entity is added to the context,
            // not all relationships are established.
            // I don't think this is correct.
            // The tests fails.
            Assert.True(Player.Games.Count == 1);
            Assert.True(Player.PlayerGames.Count == 1);

            Assert.True(Game.Players.Count == 1);
            Assert.True(Game.PlayerGames.Count == 1);
        }
    }
}
