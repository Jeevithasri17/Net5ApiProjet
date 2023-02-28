CREATE TABLE [dbo].[Employee] (
    [Id]    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]  VARCHAR (100)    NOT NULL,
    [Email] VARCHAR (100)    NOT NULL,
    [Phone] VARCHAR (20)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [Employee_Id]
    ON [dbo].[Employee]([Id] ASC);

