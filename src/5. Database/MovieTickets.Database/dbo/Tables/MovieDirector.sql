CREATE TABLE [dbo].[MovieDirector] (
    [Id]        BIGINT             IDENTITY (1, 1) NOT NULL,
    [MovieId]   BIGINT             NOT NULL,
    [PersonId]  BIGINT             NOT NULL,
    [CreatedAt] DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_MovieDirector] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MovieDirector_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES Movie(Id), 
    CONSTRAINT [FK_MovieDirector_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES Person(Id),
    CONSTRAINT [UQ_MovieDirector_MovieId_PersonId] UNIQUE (MovieId, PersonId) 
);

