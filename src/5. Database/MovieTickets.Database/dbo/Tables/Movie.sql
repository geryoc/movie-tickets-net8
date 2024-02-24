CREATE TABLE [dbo].[Movie] (
    [Id]                BIGINT        IDENTITY (1, 1) NOT NULL,
    [Title]             VARCHAR (500) NOT NULL,
    [DurationInMinutes] INT           NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([Id] ASC),
);



