-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBlogPost_GetCurrentUsersBlogPostsOrderByDateDesc]
	-- Add the parameters for the stored procedure here
	@AuthorId nvarchar(450)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.BlogPost WHERE AuthorId = @AuthorId ORDER BY [DateTimeCreated] DESC;
END
