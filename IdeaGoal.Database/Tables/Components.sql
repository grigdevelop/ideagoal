﻿CREATE TABLE [dbo].[Components]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(MAX) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[IdeaId] INT NOT NULL,

	FOREIGN KEY (IdeaId) REFERENCES Ideas(Id)

)
