CREATE PROCEDURE [EmployeeDB].[sp_UpdateEmployee]
    @id     UNIQUEIDENTIFIER,
    @name   NVARCHAR(100),
    @email  NVARCHAR(100),
    @phone  NVARCHAR(20) 
AS
BEGIN

    BEGIN TRY

        UPDATE EMPLOYEE 
        SET [Name] = @name, [Email] = @email, [Phone] = @phone
        WHERE [Id] = @Id;

    END TRY
    BEGIN CATCH
        
        INSERT INTO [Error].[ErrorLog] (ErrorMessage, ErrorSeverity, ErrorState, ErrorLine, ErrorTime)
        VALUES (ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_LINE(), GETDATE());
		SELECT * FROM [Error].[ErrorLog]
    END CATCH;

END