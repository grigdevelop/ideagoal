CREATE TABLE [dbo].[UserTokens]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserId] INT NOT NULL,
	[Token] NVARCHAR(255) NOT NULL,

	FOREIGN KEY (UserId) References Users(Id)
)
