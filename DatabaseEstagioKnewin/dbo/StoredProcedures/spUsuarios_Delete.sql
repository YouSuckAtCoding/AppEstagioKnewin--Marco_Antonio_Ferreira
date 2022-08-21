CREATE PROCEDURE [dbo].[spUsuarios_Delete]
	
	@Id int
	
AS
Begin
		delete from dbo.[Usuarios] where Id = @Id;
End

