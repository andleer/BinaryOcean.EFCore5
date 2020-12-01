using BinaryOcean.EFCore5.Library;
using System;
using Xunit;

namespace BinaryOcean.EFCore5.Tests
{
    public class NavLinkBaseToLeaf : TestBase 
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
        
            // The Player is the "base" of the graph.
            context.Players.Add(player);

            // After the graph base entity is added to the context,
            // all relationships are established.
            Assert.True(player.Games.Count == 1);
            Assert.True(player.PlayerGames.Count == 1);

            Assert.True(game.Players.Count == 1);
            Assert.True(game.PlayerGames.Count == 1);
        }
    }
}
