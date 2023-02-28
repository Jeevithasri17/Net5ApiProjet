CREATE TABLE [Book].[BookAuthors] (
    [BookId]   INT NOT NULL,
    [AuthorId] INT NOT NULL,
    CONSTRAINT [PK_BookAuthors] PRIMARY KEY CLUSTERED ([BookId] ASC, [AuthorId] ASC),
    CONSTRAINT [FK_BookAuthors_Authors] FOREIGN KEY ([AuthorId]) REFERENCES [Book].[Authors] ([AuthorId]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookAuthors_Books] FOREIGN KEY ([BookId]) REFERENCES [Book].[Books] ([BookId]) ON DELETE CASCADE
);

