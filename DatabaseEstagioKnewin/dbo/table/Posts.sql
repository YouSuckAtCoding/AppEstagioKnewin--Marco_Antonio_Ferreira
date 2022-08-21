﻿CREATE TABLE [dbo].[Posts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Author] NVARCHAR(50) NOT NULL, 
    [PublishDate] DATETIME NOT NULL, 
    [Content] NVARCHAR(200) NOT NULL
)
