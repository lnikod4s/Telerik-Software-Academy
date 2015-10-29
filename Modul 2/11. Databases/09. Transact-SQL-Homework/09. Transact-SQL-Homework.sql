-------------------------------------------------------------------------------
-- TASK 01: Create a database with two tables: Persons(Id(PK), FirstName, Last-
-- Name, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
-- Insert few records for testing.
-- Write a stored procedure that selects the full names of all persons.
-------------------------------------------------------------------------------

USE master
GO

-- Create a db named 'AccountsManagement'
CREATE DATABASE AccountsManagement
GO

-- Checkout db 'AccountsManagement'
USE AccountsManagement
GO

-- Create a new table named 'Persons'
CREATE TABLE Persons (
	Id int IDENTITY NOT NULL PRIMARY KEY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN nvarchar(50) NOT NULL
)
GO

-- Create a new table named 'Accounts'
CREATE TABLE Accounts (
	Id int IDENTITY NOT NULL PRIMARY KEY,
	PersonId int NOT NULL FOREIGN KEY REFERENCES Persons(Id),
	Balance money NOT NULL
)
GO

-- Insert few records for testing purposes
DECLARE @counter tinyint
SET @counter = 20
WHILE @counter > 0
	BEGIN
		INSERT INTO Persons(FirstName, LastName, SSN)
		VALUES ('John ' + CAST(@counter AS varchar(10)),
				'Doe ' + CAST(@counter AS varchar(10)),
				@counter + 1000000)
		SET @counter = @counter - 1
	END
GO
	
-- Insert few accounts for testing purposes
DECLARE @counter tinyint
SET @counter = 20
WHILE @counter > 0
	BEGIN
		-- Generate a random number
		DECLARE @randomNumber int
		SELECT @randomNumber = ABS(CAST(NEWID() AS binary(6)) % 10000) + 1
		
		INSERT INTO Accounts(PersonId, Balance)
		VALUES (@counter, @randomNumber)
		SET @counter = @counter - 1
	END
GO

-- Write a stored procedure that selects the full names of all persons
CREATE PROCEDURE usp_SelectFullNames
AS 
	SELECT CONCAT(FirstName, ' ', LastName) AS [FullName]
	FROM Persons
GO

-- EXEC usp_SelectFullNames

-------------------------------------------------------------------------------
-- TASK 02: Create a stored procedure that accepts a number as a parameter and 
-- returns all persons who have more money in their accounts than the supplied 
-- number.
-------------------------------------------------------------------------------

CREATE PROCEDURE usp_SelectPersonsWithGreatherBalanceThan (
	@minBalance money = 1000)
AS 
	SELECT *
	FROM Persons p
	JOIN Accounts a
		ON p.Id = a.PersonId
	WHERE a.Balance > @minBalance
	ORDER BY a.Balance
GO

-- EXEC usp_SelectPersonsWithGreatherBalanceThan 2000;

-------------------------------------------------------------------------------
-- TASK 03: Create a function that accepts as parameters – sum, yearly interest
-- rate and number of months.
-- It should calculate and return the new sum.
-- Write a SELECT to test whether the function works as expected.
-------------------------------------------------------------------------------

CREATE FUNCTION dbo.ufn_CalculateCompoundInterest (
	@sum money, @yearlyInterestRate float, numberOfMonths tinyint)
	RETURNS money
AS
	BEGIN
		RETURN @sum * (1 + @yearlyInterestRate / 12) * @numberOfMonths
	END
GO

SELECT Balance, ROUND(dbo.ufn_CalculateCompoundInterest(Balance, 0.05, 10), 2) as [Bonus]
FROM Accounts

-------------------------------------------------------------------------------
-- TASK 04: Create a stored procedure that uses the function from the previous 
-- example to give an interest to a person's account for one month.
-- It should take the AccountId and the interest rate as parameters.
-------------------------------------------------------------------------------

CREATE PROCEDURE dbo.usp_CalculateCompoundInterestForOneMonth(
	@accountId int, yearlyInterestRate float)
AS
	DECLARE @balance money
	SELECT @balance = Balance FROM Accounts WHERE Id = @accountId
	
	DECLARE @newBalance money
	SELECT @newBalance = dbo.ufn_CalculateCompoundInterest(@balance, @yearlyInterestRate, 1)
	
	SELECT p.FirstName, p.LastName, a.Balance, @newBalance AS [New Balance]
	FROM Persons p
	JOIN Accounts a
		ON p.Id = a.PersonId
	WHERE a.Id = @accountId
GO

EXEC dbo.usp_CalculateCompoundInterestForOneMonth 1, 0.1

-------------------------------------------------------------------------------
-- TASK 05: Add two more stored procedures WithdrawMoney(AccountId, money) and 
-- DepositMoney(AccountId, money) that operate in transactions.
-------------------------------------------------------------------------------

CREATE PROCEDURE dbo.usp_WithdrawMoney(@accountId int, @money money)
AS
    BEGIN TRAN
        UPDATE Accounts
        SET Balance -= @money
        WHERE AccountId = @accountId
    COMMIT TRAN
GO

CREATE PROCEDURE dbo.usp_DepositMoney(@accountId int, @money money)
AS
    BEGIN TRAN
        UPDATE Accounts
        SET Balance += @money
        WHERE AccountId = @accountId
    COMMIT TRAN
GO

EXEC dbo.usp_WithdrawMoney 1, 1000

EXEC dbo.usp_DepositMoney 2, 2000

-------------------------------------------------------------------------------
-- TASK 06: Create another table – Logs(LogID, AccountID, OldSum, NewSum).
-- Add a trigger to the Accounts table that enters a new entry into the Logs 
-- table every time the sum on an account changes.
-------------------------------------------------------------------------------

CREATE TABLE Logs (
    LogId int IDENTITY PRIMARY KEY,
    AccountId int NOT NULL FOREIGN KEY REFERENCES Accounts(AccountId),
    OldSum money NOT NULL,
    NewSum money NOT NULL
)

CREATE TRIGGER tr_UpdateAccountBalance ON Accounts FOR UPDATE
AS
    DECLARE @oldSum money;
    SELECT @oldSum = Balance FROM deleted;

    INSERT INTO Logs(AccountId, OldSum, NewSum)
        SELECT AccountId, @oldSum, Balance
        FROM inserted
GO

EXEC usp_WithdrawMoney 1, 1000

EXEC usp_DepositMoney 2, 2000

-------------------------------------------------------------------------------
-- TASK 07: Define a function in the database TelerikAcademy that returns all 
-- Employee's names (first or middle or last name) and all town's names that 
-- are comprised of given set of letters.
-- Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 
-- 'Guy'.
-------------------------------------------------------------------------------

USE TelerikAcademy
GO

CREATE FUNCTION ufn_SearchForWordsInGivenPattern(@pattern nvarchar(255))
	RETURNS @MatchedNames TABLE (Name varchar(50))
AS
BEGIN
	INSERT @MatchedNames
	SELECT * 
	FROM
		(SELECT e.FirstName FROM Employees e
        UNION
        SELECT e.LastName FROM Employees e
        UNION 
        SELECT t.Name FROM Towns t) as temp(name)
    WHERE PATINDEX('%[' + @pattern + ']', Name) > 0
	RETURN
END
GO

-- SELECT * FROM dbo.ufn_SearchForWordsInGivenPattern('oistmiahf')

-------------------------------------------------------------------------------
-- TASK 08: Using database cursor write a T-SQL script that scans all employees
-- and their addresses and prints all pairs of employees that live in the same 
-- town.
-------------------------------------------------------------------------------

DECLARE empCursor CURSOR READ_ONLY FOR
    SELECT emp1.FirstName, emp1.LastName, t1.Name, emp2.FirstName, emp2.LastName
    FROM Employees emp1
    JOIN Addresses a1
        ON emp1.AddressID = a1.AddressID
    JOIN Towns t1
        ON a1.TownID = t1.TownID,
        Employees emp2
    JOIN Addresses a2
        ON emp2.AddressID = a2.AddressID
    JOIN Towns t2
        ON a2.TownID = t2.TownID
    WHERE t1.TownID = t2.TownID AND emp1.EmployeeID != emp2.EmployeeID
    ORDER BY emp1.FirstName, emp2.FirstName

OPEN empCursor

DECLARE @firstName1 nvarchar(50), 
        @lastName1 nvarchar(50),
        @townName nvarchar(50),
        @firstName2 nvarchar(50),
        @lastName2 nvarchar(50)
FETCH NEXT FROM empCursor INTO @firstName1, @lastName1, @townName, @firstName2, @lastName2

DECLARE @counter int;
SET @counter = 0;

WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @counter = @counter + 1;

		PRINT @firstName1 + ' ' + @lastName1 + 
			  '     ' + @townName + '       ' +
			  @firstName2 + ' ' + @lastName2;

		FETCH NEXT FROM empCursor 
		INTO @firstName1, @lastName1, @townName, @firstName2, @lastName2
	END

print 'Total records: ' + CAST(@counter AS nvarchar(10));

CLOSE empCursor
DEALLOCATE empCursor

-------------------------------------------------------------------------------
-- TASK 09: *Write a T-SQL script that shows for each town a list of all emplo-
-- yees that live in it.
-- Sample output:
-- Sofia -> Martin Kulov, George Denchev
-- Ottawa -> Jose Saraiva
-- …
-------------------------------------------------------------------------------

IF NOT EXISTS (
    SELECT value
    FROM sys.configurations
    WHERE name = 'clr enabled' AND value = 1
)
BEGIN
    EXEC sp_configure @configname = clr_enabled, @configvalue = 1
    RECONFIGURE
END
GO

-- Remove the aggregate and assembly if they're there
IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
    DROP Aggregate concat; 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP assembly concat_assembly; 
GO      

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'C:\SqlStringConcatenation.dll' --- CHANGE THE LOCATION
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.concat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL Name concat_assembly.concat; 
GO 

--- CURSOR
DECLARE empCursor CURSOR READ_ONLY FOR
    SELECT t.Name, dbo.concat(e.FirstName + ' ' + e.LastName, ', ')
    FROM Towns t
    JOIN Addresses a
        ON t.TownID = a.TownID
    JOIN Employees e
        ON a.AddressID = e.AddressID
    GROUP BY t.Name
    ORDER BY t.Name

OPEN empCursor

DECLARE @townName nvarchar(50), 
        @employeesNames nvarchar(max)        
FETCH NEXT FROM empCursor INTO @townName, @employeesNames

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT @townName + ' -> ' + @employeesNames;

    FETCH NEXT FROM empCursor 
    INTO @townName, @employeesNames
END

CLOSE empCursor
DEALLOCATE empCursor
GO

DROP Aggregate concat; 
DROP assembly concat_assembly; 
GO

-------------------------------------------------------------------------------
-- TASK 10: Define a .NET aggregate function StrConcat that takes as input a 
-- sequence of strings and return a single string that consists of the input 
-- strings separated by ','.
-- For example the following SQL statement should return a single string:
-- SELECT StrConcat(FirstName + ' ' + LastName)
-- FROM Employees
-------------------------------------------------------------------------------

IF NOT EXISTS (
    SELECT value
    FROM sys.configurations
    WHERE name = 'clr enabled' AND value = 1
)
BEGIN
    EXEC sp_configure @configname = clr_enabled, @configvalue = 1
    RECONFIGURE
END
GO

-- Remove the aggregate and assembly if they're there
IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
    DROP Aggregate concat; 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP assembly concat_assembly; 
GO      

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'C:\SqlStringConcatenation.dll' --- CHANGE THE LOCATION
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.concat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL Name concat_assembly.concat; 
GO 

SELECT dbo.concat(FirstName + ' ' + LastName, ', ')
FROM Employees
GO

DROP Aggregate concat; 
DROP assembly concat_assembly; 
GO