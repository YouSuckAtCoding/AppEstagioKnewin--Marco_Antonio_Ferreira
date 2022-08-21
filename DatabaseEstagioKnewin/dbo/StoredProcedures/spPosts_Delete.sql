CREATE PROCEDURE [dbo].[spPosts_Delete]
	@Id int
	
AS
Begin
		delete from dbo.[Posts] where Id = @Id;
End

