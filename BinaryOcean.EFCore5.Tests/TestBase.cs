using BinaryOcean.EFCore5.Library;
using Microsoft.EntityFrameworkCore;

namespace BinaryOcean.EFCore5.Tests
{
    public abstract class TestBase
    {
        protected Context Context;

        protected Player Player;
        protected Game Game;
        protected PlayerGame PlayerGame;

        protected Context GetContext()
        {
            var builder = new DbContextOptionsBuilder<Context>()
               .UseInMemoryDatabase("test");
                
            return new Context(builder.Options);
        }
    }
}
