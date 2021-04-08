Create procedure dbo.spBlogPost_GetAll
as
begin

	select [Id], [AuthorId], [Title], [Content], [DateTimeCreated], [DateTimeLastEdited]
	from dbo.BlogPost;

end


