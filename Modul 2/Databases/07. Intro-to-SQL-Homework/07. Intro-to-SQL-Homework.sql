======================================================================== 
TASK 01: What is SQL? What is DML? What is DDL? Recite 
the most important SQL commands. 
========================================================================

SQL (Structured Query Language) is a standard interactive and 
programming language for getting information from and updating a 
database. Although SQL is both an ANSI and an ISO standard, many 
database products support SQL with proprietary extensions to the 
standard language. Queries take the form of a command language that 
lets you select, insert, update, find out the location of data, and so
forth. There is also a programming interface.

======================================================================== 
TASK 02: What is Transact-SQL (T-SQL)?
========================================================================

T-SQL (Transact SQL) is an extension to the standard SQL language.
T-SQL is the standard language used in MS SQL Server.
Supports if statements, loops, exceptions.
Constructions used in the high-level procedural programming languages.
T-SQL is used for writing stored procedures, functions, triggers, etc.

======================================================================== 
TASK 04: Write a SQL query to find all information about all departments
(use "TelerikAcademy" database).
========================================================================

SELECT *
  FROM [TelerikAcademy].[dbo].[Departments]

======================================================================== 
TASK 05: Write a SQL query to find all department names.
========================================================================

SELECT Name
  FROM [TelerikAcademy].[dbo].[Departments]

======================================================================== 
TASK 06: Write a SQL query to find the salary of each employee.
========================================================================

SELECT Salary
  FROM [TelerikAcademy].[dbo].[Employees]

======================================================================== 
TASK 07: Write a SQL to find the full name of each employee.
========================================================================

SELECT FirstName + ' ' + LastName AS [Full Name]
  FROM [TelerikAcademy].[dbo].[Employees]

======================================================================== 
TASK 08: Write a SQL query to find the email addresses of each employee 
(by his first and last name). Consider that the mail domain is 
telerik.com. Emails should look like "John.Doe@telerik.com". The 
produced column should be named "Full Email Addresses".
========================================================================

SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
  FROM [TelerikAcademy].[dbo].[Employees]

======================================================================== 
TASK 09: Write a SQL query to find all different employee salaries.
========================================================================

SELECT DISTINCT Salary
  FROM [TelerikAcademy].[dbo].[Employees]

======================================================================== 
TASK 10: Write a SQL query to find all information about the employees 
whose job title is "Sales Representative".
========================================================================

SELECT *
  FROM [TelerikAcademy].[dbo].[Employees]
  WHERE JobTitle = 'Sales Representative'

======================================================================== 
TASK 11: Write a SQL query to find the names of all employees whose 
first name starts with "SA".
========================================================================

SELECT *
  FROM [TelerikAcademy].[dbo].[Employees]
  WHERE FirstName LIKE 'SA%'

======================================================================== 
TASK 12: Write a SQL query to find the names of all employees whose last
name contains "ei".
========================================================================

SELECT *
  FROM [TelerikAcademy].[dbo].[Employees]
  WHERE LastName LIKE '%ei%'
  
======================================================================== 
TASK 13: Write a SQL query to find the salary of all employees whose 
salary is in the range [20000…30000].
========================================================================

SELECT *
  FROM [TelerikAcademy].[dbo].[Employees]
  WHERE Salary BETWEEN 20000 AND 30000

======================================================================== 
TASK 14: Write a SQL query to find the names of all employees whose 
salary is 25000, 14000, 12500 or 23600.
========================================================================

SELECT *
  FROM [TelerikAcademy].[dbo].[Employees]
  WHERE Salary IN (25000, 14000, 12500, 23600)
  
======================================================================== 
TASK 15: Write a SQL query to find all employees that do not have manager.
========================================================================

SELECT *
  FROM [TelerikAcademy].[dbo].[Employees]
  WHERE ManagerID IS NULL

======================================================================== 
TASK 16: Write a SQL query to find all employees that have salary more 
than 50000. Order them in decreasing order by salary.
========================================================================

SELECT TOP 5
  FROM [TelerikAcademy].[dbo].[Employees]
  WHERE Salary > 50000
  ORDER BY Salary DESC

======================================================================== 
TASK 17: Write a SQL query to find the top 5 best paid employees.
========================================================================

SELECT TOP 5 FirstName, LastName, Salary
  FROM [TelerikAcademy].[dbo].[Employees]
  ORDER BY Salary DESC
  
======================================================================== 
TASK 18: Write a SQL query to find all employees along with their 
address. Use inner join with ON clause.
========================================================================

SELECT e.FirstName, e.LastName, e.AddressID, d.AddressID, d.AddressText
  FROM [TelerikAcademy].[dbo].[Employees] e
    INNER JOIN [TelerikAcademy].[dbo].[Addresses] d
	  ON e.AddressID = d.AddressID
      
======================================================================== 
TASK 19: Write a SQL query to find all employees and their address. Use 
equijoins (conditions in the WHERE clause).
========================================================================

SELECT e.FirstName, e.LastName, d.AddressText
  FROM [TelerikAcademy].[dbo].[Employees] e, [TelerikAcademy].[dbo].[Addresses] d
  WHERE e.AddressID = d.AddressID

======================================================================== 
TASK 20: Write a SQL query to find all employees along with their manager.
========================================================================

SELECT e.FirstName + ' ' + e.LastName + ' is managed by ' + m.FirstName + ' ' + m.LastName AS Message
  FROM [TelerikAcademy].[dbo].[Employees] e JOIN [TelerikAcademy].[dbo].[Employees] m
    ON e.ManagerID = m.EmployeeID

======================================================================== 
TASK 21: Write a SQL query to find all employees, along with their 
manager and their address. Join the 3 tables: Employees e, Employees m 
and Addresses a.
========================================================================

SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name],
	   a.AddressText AS [Employee Address],
       m.FirstName + ' ' + m.LastName AS [Manager Full Name]
  FROM [TelerikAcademy].[dbo].[Employees] e 
    JOIN [TelerikAcademy].[dbo].[Employees] m
      ON e.ManagerID = m.EmployeeID
	JOIN [TelerikAcademy].[dbo].[Addresses] a
	  ON e.AddressID = a.AddressID

======================================================================== 
TASK 22: Write a SQL query to find all departments and all town names as
a single list. Use UNION.
========================================================================

SELECT Name AS [Departments and Towns]
  FROM [TelerikAcademy].[dbo].[Departments]
UNION
SELECT Name AS [Departments and Towns]
  FROM [TelerikAcademy].[dbo].[Towns]

======================================================================== 
TASK 23: Write a SQL query to find all the employees and the manager for
each of them along with the employees that do not have manager. Use right
outer join. Rewrite the query to use left outer join.
========================================================================

SELECT e.FirstName + ' ' + e.LastName + ' is managed by ' + m.FirstName + ' ' + m.LastName AS Message
  FROM [TelerikAcademy].[dbo].[Employees] e RIGHT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m
    ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName + ' is managed by ' + m.FirstName + ' ' + m.LastName AS Message
  FROM [TelerikAcademy].[dbo].[Employees] e LEFT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m
    ON e.ManagerID = m.EmployeeID

======================================================================== 
TASK 24: Write a SQL query to find the names of all employees from the 
departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
========================================================================

SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name],
       e.HireDate,
	   d.Name
  FROM [TelerikAcademy].[dbo].[Employees] e
    JOIN [TelerikAcademy].[dbo].[Departments] d
	  ON e.DepartmentID = d.DepartmentID
  WHERE (d.Name = 'Sales' OR d.Name = 'Finance') AND
	    (e.HireDate BETWEEN '1995-01-01 00:00:00' AND '2005-01-01 00:00:00')