CREATE TABLE [EmployeeDB].[Employee] (
    [Id]    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]  NVARCHAR (100)   NOT NULL,
    [Email] NVARCHAR (100)   NOT NULL,
    [Phone] NVARCHAR (20)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

