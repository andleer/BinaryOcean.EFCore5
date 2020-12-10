# BinaryOcean.EFCore5: Many to Many Questions

The new EF Core 5.0 now supports direct many to many navigation. Great stuff! I have been able to get this to work but do have some issues. I wonder if these are the result of issues in my code or have I identified a bug? Guessing the former but thought I would put this out there and solicit some feedback. Also the latest 5.0.1 release seems to have resolved some of my earlier issues but I can't find an official release doc so it is hard to know for sure. 

My code contains three entities: `Player`, `Game` and `PlayerGame`. The latter being a simple mapping table between the `Player` and the `Game`.

1. The two unit tests document similar functionality on the three entities. `ManyToManyLink` connects the object graph using the new style many to many functionality that automatically connect the two entites via the defined mapping table. It works fine and correctly establishes the mapping table entry. The `MapLink` directly connects the object graph by adding the `Player` and `Game` entities to the `PlayerGame` mapping entity. I was expending the `Player` and `Game` many to many collections to be populated but they are not.

1. I am still confused by the best approach to populating the "payload" on the mapping entity? In my case I have a PlayerRole enumeration. Fundamentally I am stuck around this. If I use the first approach so that I can directly set the payload on the mapping table, my code fails for the reasons described in the first case. If I connect the graph using either the `Player.Games` or the `Game.Players` many to many collections, I don't have access to the payload and I would assume `SaveChanges()` fails when writing to SQL with a constraint on the column.

Thoughts?

