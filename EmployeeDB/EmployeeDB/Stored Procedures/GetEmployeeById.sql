CREATE PROCEDURE [EmployeeDB].[GetEmployeeById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT Id, [Name], Email, Phone
    FROM [EmployeeDB].[Employee]
    WHERE Id = @Id
END