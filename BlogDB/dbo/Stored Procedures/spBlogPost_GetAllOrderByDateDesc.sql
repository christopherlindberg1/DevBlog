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
	SELECT * FROM [dbo].[BlogPost]
	ORDER BY [dbo].BlogPost.DateTimeCreated DESC;
END
