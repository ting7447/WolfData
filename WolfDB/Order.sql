CREATE TABLE [dbo].[Order]
(
	[OrderId] NVARCHAR(10) NOT NULL PRIMARY KEY,
	[CustomerId] VARCHAR(20) not null,
	[EmployeeId] VARCHAR(20) not null, 
    [Title] NVARCHAR(100) NOT NULL, 
    [ItemId] NVARCHAR(30) NOT NULL, 
    [Quantity] NUMERIC NOT NULL, 
    [OrderDate] DATETIME NOT NULL, 
    [Memo] NVARCHAR(1000) NOT NULL,
    [CreateDate] DATETIME NOT NULL, 
        [ModifyDate] DATETIME NOT NULL
        CONSTRAINT [FK_Order_1] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([EmployeeId]), 
        CONSTRAINT [FK_Order_2] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([CustomerId]),
                CONSTRAINT [FK_Order_3] FOREIGN KEY ([ItemId]) REFERENCES [Item]([ItemId])
)
