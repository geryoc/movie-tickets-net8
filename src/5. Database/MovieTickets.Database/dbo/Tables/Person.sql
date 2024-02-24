CREATE TABLE [dbo].[Person] (
    [Id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [FirstName]  VARCHAR (500) NOT NULL,
    [MiddleName] VARCHAR (500) NULL,
    [LastName]   VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC)
);

