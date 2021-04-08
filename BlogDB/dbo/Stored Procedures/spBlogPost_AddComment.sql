-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBlogPost_AddComment]
	-- Add the parameters for the stored procedure here
	@AuthorId nvarchar(450),
	@BlogPostId int,
	@CommentText text,
	@DateTimePosted datetime2(7),
	@DateTimeLastEdited datetime2(7),
	@ReplyToCommentId int = NULL
	--@Id int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @CurrentDateTime datetime2(7) = CURRENT_TIMESTAMP;

    INSERT INTO [dbo].[BlogPostComment] (AuthorId, BlogPostId, CommentText, DateTimeCreated, DateTimeLastEdited, ReplyToCommentId)
	VALUES (@AuthorId, @BlogPostId, @CommentText, @DateTimePosted, @DateTimeLastEdited, @ReplyToCommentId);

	--SELECT @Id = SCOPE_IDENTITY();
END
