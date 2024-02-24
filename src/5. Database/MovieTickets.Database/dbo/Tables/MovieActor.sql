CREATE TABLE [dbo].[MovieActor] (
    [Id]        BIGINT             IDENTITY (1, 1) NOT NULL,
    [MovieId]   BIGINT             NOT NULL,
    [PersonId]  BIGINT             NOT NULL,
    [CreatedAt] DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_MovieActor] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MovieActor_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES Movie(Id), 
    CONSTRAINT [FK_MovieActor_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES Person(Id),
    CONSTRAINT [UQ_MovieActor_MovieId_PersonId] UNIQUE (MovieId, PersonId) 
);

