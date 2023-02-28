CREATE TABLE [EmployeeDB].[EmployeeUpdateTbl] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (100) NOT NULL,
    [Email] NVARCHAR (100) NOT NULL,
    [Phone] NVARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

