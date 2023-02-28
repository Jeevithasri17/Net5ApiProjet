CREATE PROCEDURE GetEmployeeCountByDepartment
	@deptname NVARCHAR(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			IF NOT EXISTS (SELECT * FROM Department WHERE DeptName = @deptname)
				BEGIN
					RAISERROR('Department %s does not exixt', 16, 1, @deptname)
				END
			
			ELSE
				SELECT COUNT(ed.EmpId) as EmployeeCount 
				FROM EmployeeDepartmentMapping ed
				JOIN Employee	e on ed.EmpId	= e.Id 
				JOIN Department d on ed.DeptId	= d.Id
				WHERE d.DeptName = @deptname
				COMMIT TRANSACTION
			
			END TRY
	BEGIN CATCH
			ROLLBACK TRANSACTION
			DECLARE		@ErrorMessage	NVARCHAR(500)
			DECLARE		@ErrorSeverity	INT
			DECLARE		@ErrorState		INT

			SELECT 
				@ErrorMessage	=	ERROR_MESSAGE(),
				@ErrorSeverity	=	ERROR_SEVERITY(),
				@ErrorState		=	ERROR_STATE()
				RAISERROR(@ErrorMessage,@ErrorSeverity, @ErrorState);
	END CATCH
END
