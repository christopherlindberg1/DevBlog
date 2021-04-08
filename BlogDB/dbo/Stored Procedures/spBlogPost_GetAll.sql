-- =============================================
-- Author:		Christopher Lindberg
-- Create date: 2021-04-08
-- Description:	Gets all blog posts.
-- =============================================
Create procedure [dbo].[spBlogPost_GetAll]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [Id], [AuthorId], [Title], [Content], [DateTimeCreated], [DateTimeLastEdited]
	FROM dbo.BlogPost;
END


