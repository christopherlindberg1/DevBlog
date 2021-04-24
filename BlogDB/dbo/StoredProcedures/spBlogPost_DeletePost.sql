-- =============================================
-- Author:		Christopher Lindberg
-- Create date: 2021-04-08
-- Description:	Deletes a blog post.
-- =============================================
CREATE PROCEDURE [dbo].[spBlogPost_DeletePost]
	-- Add the parameters for the stored procedure here
	@Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[BlogPost] WHERE [Id] = @Id;
END
