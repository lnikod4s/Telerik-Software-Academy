USE Company;
GO

CREATE PROC dbo.usp_CreateCacheTable
AS
	CREATE TABLE QueryCacheTable (
		EmployeeName nvarchar(41),
		ProjectName nvarchar(50),
		DepartmentName nvarchar(50),
		StartDate date,
		EndDate date,
		ReportsCount int	
	);
GO

EXEC dbo.usp_CreateCacheTable;
GO

CREATE PROC dbo.usp_ComplexSelectQuery
AS
	DELETE FROM QueryCacheTable
	INSERT INTO QueryCacheTable
	SELECT
	[Employees].[FirstName] + ' ' + [Employees].[LastName] AS [EmployeeName],
	[Projects].[Name] AS [ProjectName],
	[Departments].[Name] AS [DepartmentName],
	StartDate, EndDate
	,(SELECT COUNT(*)
		FROM [Reports]
		WHERE [Time] BETWEEN [EmployeesInProjects].StartDate AND [EmployeesInProjects].EndDate
	) AS [ReportsCount]
	FROM [Employees]
		LEFT JOIN [Departments] ON [Departments].[Id] = [Employees].[DepartmentId]
		LEFT JOIN [EmployeesInProjects] ON [EmployeesInProjects].[EmployeeId] = [Employees].[Id]
		LEFT JOIN [Projects] ON [Projects].[Id] = [EmployeesInProjects].ProjectId
	ORDER BY [EmployeeId], [ProjectId]
GO

EXEC dbo.usp_ComplexSelectQuery
GO