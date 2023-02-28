CREATE TABLE [Book].[Authors] (
    [AuthorId]   INT            IDENTITY (1, 1) NOT NULL,
    [AuthorName] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([AuthorId] ASC)
);

