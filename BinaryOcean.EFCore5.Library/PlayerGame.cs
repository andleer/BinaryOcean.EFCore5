namespace BinaryOcean.EFCore5.Library
{
    public class PlayerGame : EntityBase
    {
        public int PlayerId { get; set; }

        public int GameId { get; set; }

        public PlayerRole PlayerRole { get; set; }

        public virtual Player Player { get; set; }

        public virtual Game Game { get; set; }
    }
}
