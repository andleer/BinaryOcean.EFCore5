using BinaryOcean.EFCore5.Library;
using Microsoft.EntityFrameworkCore;

namespace BinaryOcean.EFCore5.Tests
{
    public abstract class TestBase
    {
        protected Context GetContext()
        {
            var builder = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("test");

            var context = new Context(builder.Options);
            context.Database.EnsureDeleted();

            return context;
        }

        protected void Init(out Player player, out Game game, out PlayerGame playerGame)
        {
            Init(out player, out game);
            playerGame = new PlayerGame { };
        }

        protected void Init(out Player player, out Game game)
        {
            player = new Player { Name = "Andrew", };
            game = new Game { Name = "Rocket League", };
        }
    }
}
