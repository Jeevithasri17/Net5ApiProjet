CREATE TABLE [dbo].[Department] (
    [Id]       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [DeptName] VARCHAR (50)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

