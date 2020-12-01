# BinaryOcean.EFCore5

A simple setup with some tests to validate assumptions that I have around many to many. Assuming my code is wrong but the results seem a bit inconsistant.

The code is largely stripped down to simplfy structure and tests. The original application uses MS SQL Server but I observed identical test results against the EF in memory database so that seemed like the way to go.

Issues that I am hoping to resolve:

1.   Simple navigation linking 1:n seems to work as expected. When linking one many to many entity to the other, only a single, one way link is established. After adding the entities to the Context, the full linking is exspected to be established but this is not always the case.

1.  How does the new many to many functionality work with regards to the mapping table vs simple navigation linking? Should one establish links on the other after an entity is added to the Context?

1.  What is the best way to add playload values? It seem that the only approach here is to fall back and use the old style mapping table. That is still a win since the simple navigation 1:n links are useful and much improved when querying data but it would be nice to have an automatically generated mapping entity and somehow gain access to that.