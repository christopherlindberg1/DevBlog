-- =============================================
-- Author:		Christopher Lindberg
-- Create date: 2021-04-08
-- Description:	Gets all blog posts, newest post first.
-- =============================================
CREATE PROCEDURE [dbo].[spBlogPost_GetAllOrderByDateDesc]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [bp].[Id], [bp].[Title], [bp].[Content], [bp].[DateTimeCreated], [user].[DisplayUserName] AS [AuthorUserName]
	FROM [dbo].[BlogPost] AS [bp]
	INNER JOIN [dbo].[AspNetUsers] AS [user]
	ON [bp].[AuthorId] = [user].[Id]
	ORDER BY [bp].[DateTimeCreated] DESC;
END
