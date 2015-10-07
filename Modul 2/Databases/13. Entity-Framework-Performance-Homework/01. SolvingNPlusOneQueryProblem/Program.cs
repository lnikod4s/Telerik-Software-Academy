namespace SolvingNPlusOneQueryProblem
{
    using System;
    using TelerikAcademy.Models;

    internal class Program
    {
        private static void Main()
        {
            SelectEmployeesUsingIncludeMethod();
            SelectEmployeesWithoutUsingIncludeMethod();
        }

        private static void SelectEmployeesWithoutUsingIncludeMethod()
        {
            var db = new TelerikAcademyDb();
            var employees = db.Employees;
            foreach (var employee in employees)
            {
                Console.WriteLine("Name: {0}, Department: {1}, Town: {2}",
                    employee.FirstName + " " + employee.LastName,
                    employee.Department.Name,
                    employee.Address.Town.Name);
            }
        }

        private static void SelectEmployeesUsingIncludeMethod()
        {
            using (var db = new TelerikAcademyDb())
            {
                var employees = db.Employees.Include("Department").Include("Address.Town");
                foreach (var employee in employees)
                {
                    Console.WriteLine("Name: {0}, Department: {1}, Town: {2}",
                        employee.FirstName + " " + employee.LastName,
                        employee.Department.Name,
                        employee.Address.Town.Name);
                }
            }

            // Executed SQL Query

            //SELECT 
            //[Extent1].[EmployeeID] AS [EmployeeID], 
            //[Extent1].[FirstName] AS [FirstName], 
            //[Extent1].[LastName] AS [LastName], 
            //[Extent1].[MiddleName] AS [MiddleName], 
            //[Extent1].[JobTitle] AS [JobTitle], 
            //[Extent1].[DepartmentID] AS [DepartmentID], 
            //[Extent1].[ManagerID] AS [ManagerID], 
            //[Extent1].[HireDate] AS [HireDate], 
            //[Extent1].[Salary] AS [Salary], 
            //[Extent1].[AddressID] AS [AddressID], 
            //[Extent2].[DepartmentID] AS [DepartmentID1], 
            //[Extent2].[Name] AS [Name], 
            //[Extent2].[ManagerID] AS [ManagerID1], 
            //[Extent3].[AddressID] AS [AddressID1], 
            //[Extent3].[AddressText] AS [AddressText], 
            //[Extent3].[TownID] AS [TownID], 
            //[Extent4].[TownID] AS [TownID1], 
            //[Extent4].[Name] AS [Name1]
            //FROM    [dbo].[Employees] AS [Extent1]
            //INNER JOIN [dbo].[Departments] AS [Extent2] ON [Extent1].[DepartmentID] = [Extent2].[DepartmentID]
            //LEFT OUTER JOIN [dbo].[Addresses] AS [Extent3] ON [Extent1].[AddressID] = [Extent3].[AddressID]
            //LEFT OUTER JOIN [dbo].[Towns] AS [Extent4] ON [Extent3].[TownID] = [Extent4].[TownID]
        }
    }
}