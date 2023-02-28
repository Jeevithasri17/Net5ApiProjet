CREATE PROCEDURE [EmployeeDB].[DeleteEmployee]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM [EmployeeDB].[Employee]
    WHERE Id = @Id
END