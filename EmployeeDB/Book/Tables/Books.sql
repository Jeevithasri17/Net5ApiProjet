CREATE TABLE [Book].[Books] (
    [BookId]    INT            IDENTITY (1, 1) NOT NULL,
    [BookTitle] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([BookId] ASC)
);

