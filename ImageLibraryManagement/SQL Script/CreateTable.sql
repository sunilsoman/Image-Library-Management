CREATE TABLE [dbo].[ImageTable] (
    [Id]    INT             IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (50)   NOT NULL,
    [Image] VARBINARY (MAX) NOT NULL,
    [Size]  BIGINT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);