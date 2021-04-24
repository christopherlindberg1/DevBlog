-- =============================================
-- Author:		Christopher Lindberg
-- Create date: 2021-04-08
-- Description:	Gets a blog post by id.
-- =============================================
CREATE PROCEDURE [dbo].[spBlogPost_GetById]
	@Id INT 
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [user].[Id] AS AuthorId, [user].[DisplayUserName] AS AuthorUserName,
	[bp].[Id], [bp].[Title], [bp].[Content], [bp].[DateTimeCreated], [bp].[DateTimeLastEdited]
	FROM [dbo].[BlogPost] AS [bp]
	INNER JOIN [dbo].[AspNetUsers] AS [user]
	ON [bp].[AuthorId] = [user].[Id]
	WHERE [bp].[Id] = @Id;
END
