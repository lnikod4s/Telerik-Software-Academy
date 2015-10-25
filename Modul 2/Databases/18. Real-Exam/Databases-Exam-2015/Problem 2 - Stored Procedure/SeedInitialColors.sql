USE PetStore;
GO

CREATE PROCEDURE usp_SeedColorWithDefaultValues
AS
	DECLARE @colorsCount int;
	SET @colorsCount = (SELECT COUNT(*) FROM Colors);
	IF (@colorsCount = 0)
		INSERT INTO Colors VALUES
		('black'),
		('white'),
		('red'),
		('mixed')		
GO

EXEC usp_SeedColorWithDefaultValues;
GO