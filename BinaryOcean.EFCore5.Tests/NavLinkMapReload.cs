using BinaryOcean.EFCore5.Library;
using System;
using System.Linq;
using Xunit;

namespace BinaryOcean.EFCore5.Tests
{
    public class NavLinkMapReload : TestBase
    {
        [Fact]
        public void LinkEntities()
        {
            Init(out var player, out var game, out var playerGame);

            playerGame.Player = player;
            playerGame.Game = game;

            // is this the correct way to add a payload value?
            playerGame.PlayerRole = PlayerRole.Participant;

            // None of "the many to many" relationships are established.
            Assert.True(player.Games.Count == 0);
            Assert.True(player.PlayerGames.Count == 0);
            Assert.True(game.Players.Count == 0);
            Assert.True(game.PlayerGames.Count == 0);
        }

        [Fact]
        public void AttachToContext()
        {
            Init(out var player, out var game, out var playerGame);

            playerGame.Player = player;
            playerGame.Game = game;

            // is this the correct way to add a payload value?
            playerGame.PlayerRole = PlayerRole.Participant;

            using var Context = GetContext();

            // Add the map to the context. 
            Context.PlayerGames.Add(playerGame);
            Context.SaveChanges();

            player = Context.Players.Single();
            game = Context.Games.Single();

            // After the map entity is added to the context,
            // not all relationships are established.
            Assert.Equal(1, player.Games.Count); // fail
            Assert.Equal(1, player.PlayerGames.Count);
            Assert.Equal(1, game.Players.Count); // fail
            Assert.Equal(1, game.PlayerGames.Count);
        }
    }
}
