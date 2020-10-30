SELECT IIF ([Author].[AuthorFirstName] IS NULL,'', [Author].[AuthorFirstName] + ' ') + 
	IIF ([Author].[AuthorMiddleName] Is NULL,'', [Author].[AuthorMiddleName] + ' ') + 
	IIf([Author].[AuthorLastName] Is NULL,'', [Author].[AuthorLastName]) AS Name,
	[Title].[Title] 
FROM [Author] JOIN [TitleAuthor] ON [Author].[AuthorID] = [TitleAuthor].[AuthorID] 
		JOIN [Title] ON [TitleAuthor].[TitleID] = [Title].[TitleID]