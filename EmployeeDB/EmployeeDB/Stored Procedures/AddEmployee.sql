CREATE PROCEDURE [EmployeeDB].[AddEmployee]
	
	@name VARCHAR(100),
	@Email VARCHAR(100),
	@Phone VARCHAR(20)
AS
BEGIN
	INSERT INTO [EmployeeDB].[Employee] ([Name], [Email], [Phone]) VALUES(@name, @email, @phone)
END