﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Username] NVARCHAR(255) NOT NULL,
	[PasswordHash] NVARCHAR(255) NOT NULL
)
