[Back to README](README.md)
```c#
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

public class PlayerGame : EntityBase
{
    public PlayerGame() { }

    public int PlayerId { get; set; }

    public int GameId { get; set; }

    public PlayerRole PlayerRole { get; set; }

    public Player Player { get; set; }

    public Game Game { get; set; }
}
```
[Back to README](README.md)