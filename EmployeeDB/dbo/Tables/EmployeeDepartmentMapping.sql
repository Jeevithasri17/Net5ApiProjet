CREATE TABLE [dbo].[EmployeeDepartmentMapping] (
    [EmpId]  UNIQUEIDENTIFIER NULL,
    [DeptId] UNIQUEIDENTIFIER NULL,
    FOREIGN KEY ([DeptId]) REFERENCES [dbo].[Department] ([Id]),
    FOREIGN KEY ([EmpId]) REFERENCES [dbo].[Employee] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [index_EmployeeId]
    ON [dbo].[EmployeeDepartmentMapping]([EmpId] ASC);

