SELECT d.Name [Department Name], COUNT(e.Id) AS [Number of Employees]
FROM [Company].[dbo].[Departments] d
INNER JOIN [Company].[dbo].[Employees] e
ON e.DepartmentId = d.Id
GROUP BY d.Name
ORDER BY [Number of Employees]