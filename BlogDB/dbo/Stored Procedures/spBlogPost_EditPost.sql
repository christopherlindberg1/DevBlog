-- =============================================
-- Author:		Christopher Lindberg
-- Create date: 2021-04-08
-- Description:	Edits the title and content of a blog post.
-- =============================================
CREATE PROCEDURE [dbo].[spBlogPost_EditPost]
	-- Add the parameters for the stored procedure here
	@Id INT,
	@Title NVARCHAR(250),
	@Content TEXT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[BlogPost] SET [Title] = @Title, [Content] = @Content, [DateTimeLastEdited] = CURRENT_TIMESTAMP WHERE [Id] = @Id;
END
