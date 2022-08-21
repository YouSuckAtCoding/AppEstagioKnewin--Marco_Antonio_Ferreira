CREATE PROCEDURE [dbo].[spPosts_Insert]
	@Title nvarchar(50),
	@Author nvarchar(50),
	@PublishDate datetime,
	@Content nvarchar(200)
	
AS
Begin
	insert into dbo.[Posts] (Title, Author, PublishDate, Content) values
	(@Title, @Author, @PublishDate, @Content);

End

