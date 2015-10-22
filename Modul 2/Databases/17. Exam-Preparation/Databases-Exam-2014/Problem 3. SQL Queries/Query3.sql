SELECT 
	e.FirstName + ' ' + e.LastName AS [Full Name],
	p.Name AS [Project Name],
	d.Name AS [Department Name],
	ep.StartDate,
	ep.EndDate,
	(SELECT COUNT(*)
	 FROM [Company].[dbo].[Reports] r
	 WHERE r.Time >= ep.StartDate AND r.Time <= ep.EndDate) AS [ReportsCount]
FROM [Company].[dbo].[Employees] e
JOIN [Company].[dbo].[Departments] d ON e.DepartmentId = d.Id
JOIN [Company].[dbo].[EmployeesProjects] ep ON ep.EmployeeId = e.Id
JOIN [Company].[dbo].[Projects] p ON p.Id = ep.ProjectId
ORDER BY e.Id, p.Id