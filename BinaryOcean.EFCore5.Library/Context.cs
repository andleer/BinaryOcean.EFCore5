using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BinaryOcean.EFCore5.Library
{
    public class Context : DbContext 
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerGame> PlayerGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}