using System.Collections.Generic;

namespace BinaryOcean.EFCore5.Library
{
    public class Player : EntityBase
    {
        public Player()
        {
            Games = new HashSet<Game>();
            PlayerGames = new HashSet<PlayerGame>();
        }

        public int PlayerId { get; set; }

        public string Name { get; set; }

        public ICollection<Game> Games { get; }

        public ICollection<PlayerGame> PlayerGames { get; }
    }
}
