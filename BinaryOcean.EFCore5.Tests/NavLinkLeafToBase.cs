using BinaryOcean.EFCore5.Library;
using System;
using Xunit;

namespace BinaryOcean.EFCore5.Tests
{
    public class NavLinkLeafToBase : TestBase
    {
        [Fact]
        public void LinkEntities()
        {
            Init(out var player, out var game);

            player.Games.Add(game);

            // Only Player.Games is established.
            Assert.True(player.Games.Count == 1);
            Assert.True(player.PlayerGames.Count == 0);
            Assert.True(game.Players.Count == 0);
            Assert.True(game.PlayerGames.Count == 0);
        }

        [Fact]
        public void AttachToContext()
        {
            Init(out var player, out var game);
     
            player.Games.Add(game);

            using var context = GetContext();

            // The Game is the "leaf" of the graph.
            context.Games.Add(game);

            // After the leaf entity is added to the context,
            // not all relationships are established.
            // I don't think this is correct.
            // The tests fails.
            Assert.True(player.Games.Count == 1); 
            Assert.True(player.PlayerGames.Count == 1); // fail

            Assert.True(game.Players.Count == 1); // fail
            Assert.True(game.PlayerGames.Count == 1); // fail
        }
    }
}
