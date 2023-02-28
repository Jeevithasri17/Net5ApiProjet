CREATE TABLE [Error].[ErrorLog] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [ErrorMessage]  NVARCHAR (MAX) NOT NULL,
    [ErrorSeverity] INT            NOT NULL,
    [ErrorState]    INT            NOT NULL,
    [ErrorLine]     INT            NULL,
    [ErrorTime]     DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

