CREATE PROCEDURE [EmployeeDB].[UpdateEmployee]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20)
AS
BEGIN
    UPDATE [EmployeeDB].[Employee]
    SET Name = @Name,
        Email = @Email,
        Phone = @Phone
    WHERE Id = @Id
END