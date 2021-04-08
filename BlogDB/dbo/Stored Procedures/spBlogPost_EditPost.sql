-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
