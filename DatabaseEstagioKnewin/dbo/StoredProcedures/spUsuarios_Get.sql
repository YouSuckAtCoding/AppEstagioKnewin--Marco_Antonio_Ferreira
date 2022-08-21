CREATE PROCEDURE [dbo].[spUsuarios_Get]
	@Id int
AS
Begin

	select * from dbo.[Usuarios] 
	where Id = @Id;

End

