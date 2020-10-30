SELECT IIF ([Author].[AuthorFirstName] IS NULL,'', [Author].[AuthorFirstName] + ' ')  + 
		IIF ([Author].[AuthorMiddleName] IS NULL,'', [Author].[AuthorMiddleName] + ' ') + 
		IIF ([Author].[AuthorLastName] IS NULL,'', [Author].[AuthorLastName]) AS Name,
	[Title].[Title]
FROM [Author] JOIN [TitleAuthor] ON [Author].[AuthorID]=[TitleAuthor].[AuthorID]
	JOIN [Title] ON [Title].[TitleID]=[TitleAuthor].[TitleID]
WHERE (([Author].[AuthorFirstName] LIKE 'Shuffle')
	OR ([Author].[AuthorMiddleName] LIKE 'Shuffle')
	OR ([Author].[AuthorLastName] LIKE 'Shuffle')
	OR ([Title].[Title] LIKE '%Shuffle%'))
