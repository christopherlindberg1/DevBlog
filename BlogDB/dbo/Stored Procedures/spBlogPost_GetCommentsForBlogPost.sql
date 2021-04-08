-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBlogPost_GetCommentsForBlogPost] 
	-- Add the parameters for the stored procedure here
	@BlogPostId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [user].UserName AS AuthorUserName, bpc.AuthorId, bpc.CommentText, bpc.DateTimeCreated, bpc.DateTimeLastEdited, bpc.ReplyToCommentId
	FROM [dbo].[BlogPostComment] AS bpc
	INNER JOIN [dbo].[BlogPost] AS bp
	ON bp.Id = @BlogPostId
	AND bp.Id = bpc.BlogPostId
	INNER JOIN [dbo].[AspNetUsers] AS [user]
	ON [user].Id = bpc.AuthorId;
END
