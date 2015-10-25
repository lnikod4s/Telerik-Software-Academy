SELECT TOP 5 [Price],
	[Breed],
	[BirthDateTime]
FROM [PetStore].[dbo].[Pets]
WHERE YEAR([BirthDateTime]) > 2012 
ORDER BY [Price] DESC 