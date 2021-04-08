CREATE TABLE [dbo].[BlogPostComment] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [AuthorId]           NVARCHAR (450) NOT NULL,
    [BlogPostId]         INT            NOT NULL,
    [CommentText]        TEXT           NOT NULL,
    [DateTimeCreated]    DATETIME2 (7)  NOT NULL,
    [DateTimeLastEdited] DATETIME2 (7)  NOT NULL,
    [ReplyToCommentId]   INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BlogPostComment_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_BlogPostComment_BlogPostId] FOREIGN KEY ([BlogPostId]) REFERENCES [dbo].[BlogPost] ([Id]) ON DELETE CASCADE
);

