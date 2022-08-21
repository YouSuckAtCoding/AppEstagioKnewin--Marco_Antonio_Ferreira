CREATE PROCEDURE [dbo].[spPosts_Get]
	@Id int
AS
Begin

	select * from dbo.[Posts] 
	where Id = @Id;

End

