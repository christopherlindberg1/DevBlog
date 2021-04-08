CREATE TABLE [dbo].[BlogPost] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [AuthorId]           NVARCHAR (450) NOT NULL,
    [Title]              NVARCHAR (250) NOT NULL,
    [Content]            TEXT           NOT NULL,
    [DateTimeCreated]    DATETIME2 (7)  CONSTRAINT [DF_BlogPost_DateTimeCreated] DEFAULT (getdate()) NOT NULL,
    [DateTimeLastEdited] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_BlogPost] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

