CREATE TABLE [EmployeeDB].[Folders] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [ParentId] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

