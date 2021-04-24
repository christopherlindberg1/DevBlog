-- =============================================
-- Author:		Christopher Lindberg
-- Create date: 2021-04-08
-- Description:	Gets comments for a particular blog post.
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
	SELECT [user].[DisplayUserName] AS AuthorUserName,
	[bpc].[AuthorId], [bpc].[CommentText], [bpc].[DateTimeCreated],
	[bpc].[DateTimeLastEdited], [bpc].[ReplyToCommentId]
	FROM [dbo].[BlogPostComment] AS bpc
	INNER JOIN [dbo].[BlogPost] AS bp
	ON [bp].[Id] = @BlogPostId
	AND [bp].[Id] = [bpc].[BlogPostId]
	INNER JOIN [dbo].[AspNetUsers] AS [user]
	ON [user].[Id] = [bpc].[AuthorId]
	ORDER BY [bpc].[DateTimeCreated] DESC
END
