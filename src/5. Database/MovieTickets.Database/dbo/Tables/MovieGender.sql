CREATE TABLE [dbo].[MovieGender] (
    [Id]   BIGINT      IDENTITY (1, 1) NOT NULL,
    [MovieId] BIGINT NOT NULL,
    [GenderId] SMALLINT NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NOT NULL, 
    CONSTRAINT [PK_MovieGender] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MovieGender_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES Movie(Id), 
    CONSTRAINT [FK_MovieGender_Gender_GenderId] FOREIGN KEY ([GenderId]) REFERENCES Gender(Id),
    CONSTRAINT [UQ_MovieGender_MovieId_GenderId] UNIQUE (MovieId, GenderId) 
);

