CREATE PROCEDURE [dbo].[spPosts_Update]
	@Id int,
	@Title nvarchar(50),
	@Author nvarchar(50),
	@PublishDate datetime,
	@Content nvarchar(200)
	
AS
Begin

	update dbo.[Posts]
	set Title = @Title, Author = @Author, PublishDate = @PublishDate, Content = @Content
	where Id = @Id

End

