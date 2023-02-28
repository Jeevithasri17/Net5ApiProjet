CREATE TABLE [Product].[ProductDetails] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Product]      NVARCHAR (50) NULL,
    [ItemsInStock] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

