# BinaryOcean.EFCore5: Many to Many Questions

The new EF Core 5.0 now supports direct many to many navigation. Great stuff! I have been able to get this to work but do have some issues. I wonder if these are the result of issues in my code and configuration or have I identified a bug? Guessing the former but thought I would put this out there and solicit some feedback. Also the latest 5.0.1 release seems to have resolved some of my earlier issues but I can't find an official release doc so it is hard to know for sure. 

My code contains three entities: `Player`, `Game` and `PlayerGame`. The latter being a simple mapping table between the `Player` and the `Game` entities.

1. The two unit tests document similar functionality on the three entities.
   - `ManyToManyLink` connects the object graph using the new style many to many functionality that automatically connect the two entities via the defined mapping table. I make the connection in a single directipon. It works fine and correctly establishes the mapping table entry. 
    - `MapLink` directly connects the object graph by referencing the `Player` and `Game` entities in the `PlayerGame` mapping entity. I was expecting the `Player` and `Game` many to many collections to be populated but they are not. EF Core bug? Issue in my code?

1. I am still confused by the best approach to populating the "payload" on the mapping entity? In my case I have a `PlayerRole` enumeration that needs to be set. Fundamentally I am stuck around this. If I use the second approach above so that I can directly set the payload on the mapping entity/table record, my code fails for the reasons described in the first case. If I connect the graph using either the `Player.Games` or the `Game.Players` many to many collections, I don't have access to the payload and I would assume `SaveChanges()` fails when writing to SQL with a constraint on the payload column.

Thoughts?

## Other Items:

1. The `OnModelCreating ApplyConfigurationsFromAssembly` method is simply amazing. I have resisted using the fluent API preferring instead to use attributes but I can see the writing on the wall with that approach. You can't define a compound key with attributes. I went all in on the fluent API. The resulting pattern is really clean. I like having a single "configuration" class for each of my entities and the `IEntityTypeConfiguration<T>` interface makes that all possible. I also think the `EntityBase` and `ConfigureEntityBase()` method I came up with work pretty well when you have common properties across a wide range of entities. I wonder if there are other similar implementations or possible improvements that can be made?

*-Andy*

