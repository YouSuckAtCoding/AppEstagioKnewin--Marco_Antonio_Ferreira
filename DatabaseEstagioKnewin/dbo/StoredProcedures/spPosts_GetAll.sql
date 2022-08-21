CREATE PROCEDURE [dbo].[spPosts_GetAll]

AS
Begin
	
	select Id, Title, Author, PublishDate, Content from dbo.[Posts];

End

