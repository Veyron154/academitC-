CREATE TABLE [dbo].[Contact] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Surname] VARCHAR (50) NOT NULL,
    [Name]    VARCHAR (50) NOT NULL,
    [Phone]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

