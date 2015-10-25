SELECT s.Name AS [SpeciesName],
	COUNT(p.Id) AS [ProductsCount]
FROM [PetStore].[dbo].[Species] s
INNER JOIN [ProductSpecies] ps ON s.Id = ps.SpeciesId
INNER JOIN [Products] p ON ps.ProductId = p.Id
GROUP BY p.Id
ORDER BY [ProductsCount]