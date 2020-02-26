CREATE TABLE [dbo].[Customer]
(
	[CustomerId] VARCHAR(20) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [CreateDate] DATETIME NOT NULL,
    [ModifyDate] DATETIME NOT NULL
)
