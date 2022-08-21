CREATE PROCEDURE [dbo].[spUsuarios_Update]

	@Id int,
	@Name nvarchar(50),
	@EmailAddress nvarchar(100)
	
	
AS
Begin

	update dbo.[Usuarios]
	set Name = @Name, EmailAddress = @EmailAddress
	where Id = @Id

End

