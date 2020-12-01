namespace BinaryOcean.EFCore5.Library
{
    public class PlayerGame : EntityBase
    {
        public PlayerGame() { }

        public int PlayerId { get; set; }

        public int GameId { get; set; }

        public PlayerRole PlayerRole { get; set; }

        public Player Player { get; set; }

        public Game Game { get; set; }
    }
}
