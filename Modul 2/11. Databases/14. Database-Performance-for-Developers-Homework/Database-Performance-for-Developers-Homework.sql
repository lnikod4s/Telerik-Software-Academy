-----------------------------------------------------------------------------------------
-- TASK 01: Create a table in SQL Server with 10 000 000 log entries (date + text). 
-- Search in the table by date range. Check the speed (without caching).                               
-----------------------------------------------------------------------------------------

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

CREATE TABLE Trainers(
	TrainerId int NOT NULL PRIMARY KEY IDENTITY,
	TrainerName varchar(100),
	PostDate date
)
GO

INSERT INTO Trainers(TrainerName, PostDate) VALUES ('Nikolay Kostov', GETDATE())
INSERT INTO Trainers(TrainerName, PostDate) VALUES ('Doncho Minkov', GETDATE() + 1)
INSERT INTO Trainers(TrainerName, PostDate) VALUES ('Ivaylo Kenov', GETDATE() + 2)
INSERT INTO Trainers(TrainerName, PostDate) VALUES ('Evlogi Hristov', GETDATE() + 3)
INSERT INTO Trainers(TrainerName, PostDate) VALUES ('Bay Ivan', GETDATE() + 4)
INSERT INTO Trainers(TrainerName, PostDate) VALUES ('Kaka Penka', GETDATE() + 5)
INSERT INTO Trainers(TrainerName, PostDate) VALUES ('Bat Boiko', GETDATE() + 6)
INSERT INTO Trainers(TrainerName, PostDate) VALUES ('Bash Maistora', GETDATE() + 7)
INSERT INTO Trainers(TrainerName, PostDate) VALUES ('Lelya Ginka', GETDATE() + 8)
INSERT INTO Trainers(TrainerName, PostDate) VALUES ('Chicho Mitko', GETDATE() + 9)
GO

DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM Trainers) < 10000000
BEGIN
	INSERT INTO Trainers(TrainerName, PostDate)
	SELECT TrainerName + CONVERT(varchar, @Counter), GETDATE() + @Counter FROM Trainers
	SET @Counter = @Counter + 1
END
GO

-- Elapsed Time: 00:01:06
-- HomeworkDB.mdf: 477 MB
-- HomeworkDB_log.ldf: 1.30 GB

-----------------------------------------------------------------------------------------
-- TASK 02: Add an index to speed-up the search by date. Test the search speed (after 
-- cleaning the cache).                               
-----------------------------------------------------------------------------------------

CREATE INDEX IDX_Trainers_PostDate
ON Trainers(PostDate)

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Trainers
WHERE PostDate BETWEEN GETDATE() AND GETDATE() + 15

-- Elapsed Time: 00:00:05

-----------------------------------------------------------------------------------------
-- TASK 03: Add a full text index for the text column. Try to search with and without 
-- the full-text index and compare the speed.                              
-----------------------------------------------------------------------------------------

-- Creating full-text catalog and full-text index
CREATE FULLTEXT CATALOG TrainerNameFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Trainers(TrainerName)
KEY INDEX PK__Trainers__366A1A7C3E923D38
ON TrainerNameFullTextCatalog
WITH CHANGE_TRACKING AUTO


-- Searching without full-text index
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM Trainers
WHERE TrainerName LIKE 'Doncho%'
GO

-- Elapsed Time: 00:00:07

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM Trainers
WHERE TrainerName LIKE 'Nikolay%'
GO

-- Elapsed Time: 00:00:10

-- Searching with full-text index
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM Trainers
WHERE CONTAINS(TrainerName, 'Nikolay')
GO

-- Elapsed Time: 00:00:07

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM Trainers
WHERE CONTAINS(TrainerName, 'Doncho')
GO

-- Elapsed Time: 00:00:07

-----------------------------------------------------------------------------------------
-- TASK 04: Create the same table in MySQL and partition it by date (1990, 2000, 2010). 
-- Fill 1 000 000 log entries. Compare the searching speed in all partitions (random 
-- dates) to certain partition (e.g. year 1995).                           
-----------------------------------------------------------------------------------------


-- Without partitioning
CREATE SCHEMA `trainers`;

CREATE TABLE `trainers`.`logs` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`TrainerName` TEXT NOT NULL,
	`PostDate` DATETIME NOT NULL,
	PRIMARY KEY (`Id`));

-- With partitioning
CREATE SCHEMA `trainers`;

CREATE TABLE `trainers`.`logs` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`TrainerName` TEXT NOT NULL,
	`PostDate` DATETIME NOT NULL,
	PRIMARY KEY (`Id`, `PostDate`)
) PARTITION BY RANGE(YEAR(PostDate)) (
    PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
    PARTITION p2 VALUES LESS THAN (2010),
    PARTITION p3 VALUES LESS THAN MAXVALUE
);

-- EXPLAIN PARTITIONS SELECT * FROM Logs;