CREATE TABLE [dbo].[Products]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(255) NOT NULL,
    [Slug] VARCHAR(255) NOT NULL UNIQUE,
    [Description] NVARCHAR(MAX) NULL,
    [Price] DECIMAL(18, 2) NOT NULL,
    [Discount] FLOAT NOT NULL DEFAULT 0,
    [Quantity] INT NOT NULL DEFAULT 0,
    [CategoryId] INT NOT NULL,

    CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryId) 
        REFERENCES [dbo].[Categories](Id)
);