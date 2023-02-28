CREATE TABLE [EmployeeDB].[EmployeeDepartmentMapping] (
    [EmpId]  UNIQUEIDENTIFIER NULL,
    [DeptId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [fk_DEPTID] FOREIGN KEY ([DeptId]) REFERENCES [EmployeeDB].[Department] ([Id]),
    CONSTRAINT [fk_EMPID] FOREIGN KEY ([EmpId]) REFERENCES [EmployeeDB].[Employee] ([Id])
);

