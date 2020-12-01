using BinaryOcean.EFCore5.Library;
using Xunit;

namespace BinaryOcean.EFCore5.Tests
{
    public class NavLinkMap : TestBase
    {
        public NavLinkMap()
        {
            Context = GetContext();

            Player = new Player { Name = "Andrew", };
            Game = new Game { Name = "Rocket League", };

            PlayerGame = new PlayerGame
            {
                // Is this the only way to set the payload "role" value?
                PlayerRole = PlayerRole.Owner
            };
        }

        [Fact]
        public void LinkedEntities()
        {
            // Add the player and game to the "map"
            PlayerGame.Player = Player;
            PlayerGame.Game = Game;

            // None of "the many to many" relationships are established.
            Assert.True(Player.Games.Count == 0);
            Assert.True(Player.PlayerGames.Count == 0);
            Assert.True(Game.Players.Count == 0);
            Assert.True(Game.PlayerGames.Count == 0);
        }

        [Fact]
       public void AttachedToContext()
        { 
            // Add the map to the context. 
            Context.PlayerGames.Add(PlayerGame);

            // After the map entity is added to the context,
            // not all relationships are established.
            Assert.True(Player.Games.Count == 1); // fail
            Assert.True(Player.PlayerGames.Count == 1); // fail

            Assert.True(Game.Players.Count == 1); // fail
            Assert.True(Game.PlayerGames.Count == 1); // fail
        }
    }
}
