CREATE PROCEDURE [dbo].[spUsuarios_Insert]

	@Name nvarchar(50),
	@EmailAddress nvarchar(100)
	
	
AS
Begin
	insert into dbo.[Usuarios] (Name, EmailAddress) values
	(@Name, @EmailAddress);

End

