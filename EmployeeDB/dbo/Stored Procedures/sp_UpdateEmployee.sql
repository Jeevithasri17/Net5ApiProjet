CREATE PROCEDURE [sp_UpdateEmployee]
	@id		UNIQUEIDENTIFIER,
	@name	NVARCHAR(100),
	@email	NVARCHAR(100),
	@phone	NVARCHAR(20)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE EMPLOYEE 
			SET [Name] = @name, [Email] = @email, [Phone] = @phone
			WHERE [Id] = @Id;
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH;
END
	