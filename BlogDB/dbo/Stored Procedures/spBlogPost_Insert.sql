CREATE PROCEDURE [dbo].[spBlogPost_Insert]
	@AuthorId nvarchar(450),
	@Title nvarchar(250),
	@Content text,
	@DateTimeCreated datetime2(7),
	@DateTimeLastEdited datetime2(7),
	@Id int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO dbo.[BlogPost](AuthorId, Title, Content, DateTimeCreated, DateTimeLastEdited)
	VALUES (@AuthorId, @Title, @Content, @DateTimeCreated, @DateTimeLastEdited);

	SELECT @Id = SCOPE_IDENTITY();
END
