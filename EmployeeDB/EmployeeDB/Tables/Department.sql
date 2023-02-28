CREATE TABLE [EmployeeDB].[Department] (
    [Id]       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [DeptName] NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

