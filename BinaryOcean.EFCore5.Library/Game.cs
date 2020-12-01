using System.Collections.Generic;

namespace BinaryOcean.EFCore5.Library
{
    public class Game : EntityBase
    {
        public Game()
        {
            Players = new HashSet<Player>();
            PlayerGames = new HashSet<PlayerGame>();
        }

        public int GameId { get; set; }

        public string Name { get; set; }

        public ICollection<Player> Players { get; }

        public ICollection<PlayerGame> PlayerGames { get; }
    }
}
