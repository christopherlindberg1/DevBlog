CREATE PROCEDURE [dbo].[spBlogPost_Insert]
	@AuthorId nvarchar(450),
	@Title nvarchar(250),
	@Content text,
	@DateTimeCreated datetime2(7),
	@DateTimeLastEdited datetime2(7),
	@Id int OUTPUT
AS
begin

	set nocount on;

	insert into dbo.[BlogPost](AuthorId, Title, Content, DateTimeCreated, DateTimeLastEdited)
	values (@AuthorId, @Title, @Content, @DateTimeCreated, @DateTimeLastEdited);

	SELECT @Id = SCOPE_IDENTITY();

end
