CREATE TABLE [EmployeeDB].[sales] (
    [id]          INT             IDENTITY (1, 1) NOT NULL,
    [salesperson] VARCHAR (50)    NULL,
    [sale_amount] DECIMAL (10, 2) NULL,
    [sale_date]   DATE            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

