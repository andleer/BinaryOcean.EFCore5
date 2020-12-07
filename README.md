# BinaryOcean.EFCore5: Many to Many Questions

This repo contains a simple setup with some tests to validate and debug assumptions that I have around the new EF Core 5 many to many relationships. You guys are the experts so I will assume my code is wrong but at the least, the results seem a bit inconsistant.

The code is largely stripped down to simplfy structure and tests. The original application uses MS SQL Server but I observed identical test results against the EF in memory database so that seemed like the way to go for this test repo.

## Issues that I am hoping to resolve or beter understand:

I have devined a model that has 3 real entities. `Player`, `Game` and a mapping table `PlayerGame`. The PlayerGame table includes a payload item named `PlayerRole`.

[Entity Source](EntitySource.md)