--TRUNCATE TABLE Large_table_3;

/*CREATE TABLE Large_table_3
(
	id INT NOT NULL IDENTITY(1, 1),
	color VARCHAR(25) NULL,
	size VARCHAR(25) NULL
)*/
GO
DECLARE @i INT = 0
DECLARE @var INT = 1;
WHILE @i < 1000000
	BEGIN
		IF @i IN (999999, 999995, 999993)
			SET @var = 999
		ELSE SET @var = 1;
		INSERT Large_table_3 (color, size) VALUES
		(
			'COLOR ' + CAST(@var AS VARCHAR(5)),
			'SIZE '  + CAST(@var AS VARCHAR(5))
		);
		SET @i = @i + 1
	END