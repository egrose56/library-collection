CREATE TABLE [dbo].[TableISBN] (
    [ISBNId]     BIGINT       IDENTITY (1, 1) NOT NULL,
    [ISBN]       VARCHAR (50) NULL,
    [BookTypeID] TINYINT    NULL,
    PRIMARY KEY CLUSTERED ([ISBNId] ASC)
);

