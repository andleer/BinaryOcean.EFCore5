using BinaryOcean.EFCore5.Library;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace BinaryOcean.EFCore5.Tests
{
    public class ManyToManyLink
    {
        private Player player = new Player { Name = "Andrew", };
        private Game game = new Game { Name = "Rocket League", };

        private Context Context;

        public ManyToManyLink()
        {
            player.Games.Add(game);

            var builder = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(nameof(ManyToManyLink));
            Context = new Context(builder.Options);
            Context.Database.EnsureDeleted();

            Context.Players.Add(player);
            Context.SaveChanges();
        }

        [Fact]
        public void PlayerHasSingleGame()
        {
            Assert.Equal(1, player.Games.Count);
        }

        [Fact]
        public void PlayerHasSinglePlayerGame()
        {
            Assert.Equal(1, player.PlayerGames.Count);
        }

        [Fact]
        public void GameHasSinglePLayer()
        {
            Assert.Equal(1, game.Players.Count);
        }

        [Fact]
        public void GameHasSingPlayerGame()
        {
            Assert.Equal(1, game.PlayerGames.Count);
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
        public void ContextHasSinglePlayerGame()
        {
            Assert.Equal(1, Context.PlayerGames.Count());
        }
    }
}
