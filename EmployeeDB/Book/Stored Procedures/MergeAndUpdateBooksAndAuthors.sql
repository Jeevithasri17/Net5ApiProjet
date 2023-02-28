CREATE PROCEDURE [Book].[MergeAndUpdateBooksAndAuthors]
    @bookId int,
    @bookTitle varchar(100)
AS
BEGIN
 
    -- Perform the merge operation on the Books table
    MERGE [Book].[BooksUpdated] AS targettbl
    --USING [Book].[Books] AS sourcetbl
	USING (SELECT @bookId, @bookTitle) AS sourcetbl (BookId, BookTitle)
    ON targettbl.BookId = sourcetbl.BookId
    WHEN MATCHED THEN
        UPDATE SET BookTitle = @bookTitle
    WHEN NOT MATCHED THEN
        INSERT ( BookTitle) VALUES ( sourcetbl.BookTitle)
	WHEN NOT MATCHED BY SOURCE THEN 
		DELETE;

    
    -- Perform the cascading delete operation on the BookAuthors table
    --DELETE FROM [Book].[Books] WHERE BookId = 4

    -- Output the results
    SELECT * FROM [Book].[Books];
    SELECT * FROM [Book].[Authors];
    SELECT * FROM [Book].[BookAuthors];
	SELECT * FROM [Book].[BooksUpdated];
END