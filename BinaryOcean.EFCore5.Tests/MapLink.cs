using BinaryOcean.EFCore5.Library;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace BinaryOcean.EFCore5.Tests
{
    public class MapLink
    {
        private Player Player = new Player { Name = "Andrew", };
        private Game Game = new Game { Name = "Rocket League", };
        private PlayerGame PlayerGame = new PlayerGame { PlayerRole = PlayerRole.Participant, };

        private Context Context;

        public MapLink()
        {
            PlayerGame.Player = Player;
            PlayerGame.Game = Game;

            var builder = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(nameof(MapLink));
            Context = new Context(builder.Options);
            Context.Database.EnsureDeleted();

            Context.PlayerGames.Add(PlayerGame);
            Context.SaveChanges();
        }

        [Fact]
        public void PlayerHasSingleGames()
        {
            Assert.Equal(1, Player.Games.Count); // fail
        }

        [Fact]
        public void PlayerHasSinglePlayerGame()
        {
            Assert.Equal(1, Player.PlayerGames.Count);
        }

        [Fact]
        public void GamesHasSinglePlayers()
        {
            Assert.Equal(1, Game.Players.Count); // fail
        }

        [Fact]
        public void GameHasSinglePlayerGame()
        {
            Assert.Equal(1, Game.PlayerGames.Count);
        }

        [Fact]
        public void ContextHasSinglePlayerGames()
        {
            Assert.Equal(1, Context.PlayerGames.Count());
        }

        [Fact]
        public void ContextHasSinglePlayer()
        {
            Assert.Equal(1, Context.Players.Count());
        }

        [Fact]
        public void ContextHasSingleGame()
        {
            Assert.Equal(1, Context.Games.Count());
        }

        [Fact]
        public void ContextPlayerHasSingleGames()
        {
            Assert.Equal(1, Context.Players.Single().Games.Count);
        }
    }
}
