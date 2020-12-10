using BinaryOcean.EFCore5.Library;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace BinaryOcean.EFCore5.Tests
{
    public class ManyToManyLink
    {
        private Player Player = new Player { Name = "Andrew", };
        private Game Game = new Game { Name = "Rocket League", };
        //private PlayerGame PlayerGame = new PlayerGame { PlayerRole = PlayerRole.Participant, };

        private Context Context;

        public ManyToManyLink()
        {
            Player.Games.Add(Game);


            var builder = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(nameof(ManyToManyLink));
            Context = new Context(builder.Options);
            Context.Database.EnsureDeleted();

            Context.Players.Add(Player);
            Context.SaveChanges();
        }

        [Fact]
        public void PlayerHasSingleGame() => Assert.Equal(1, Player.Games.Count);

        [Fact]
        public void GameHasSinglePlayer() => Assert.Equal(1, Game.Players.Count);

        [Fact]
        public void ContextPlayerHasSingleGame() => Assert.Equal(1, Context.Players.Single().Games.Count); // fail

        [Fact]
        public void PlayerHasSinglePlayerGame() => Assert.Equal(1, Player.PlayerGames.Count);

        [Fact]
        public void GameHasSinglePlayerGame() => Assert.Equal(1, Game.PlayerGames.Count);

        [Fact]
        public void ContextHasSinglePlayer() => Assert.Equal(1, Context.Players.Count());

        [Fact]
        public void ContextHasSingleGame() => Assert.Equal(1, Context.Games.Count());

        [Fact]
        public void ContextHasSinglePlayerGame() => Assert.Equal(1, Context.PlayerGames.Count());
    }
}
