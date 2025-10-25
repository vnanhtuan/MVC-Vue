CREATE TABLE [dbo].[ProductImages]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    
    -- Cột liên kết đến bảng Products
    [ProductId] INT NOT NULL,
    
    [Url] VARCHAR(500) NOT NULL,
    [IsMain] BIT NOT NULL DEFAULT 0,
    [DisplayOrder] SMALLINT NULL DEFAULT 0,

    -- ĐỊNH NGHĨA KHÓA NGOẠI:
    -- Khóa ngoại liên kết cột ProductId với cột Id trong bảng Products.
    -- ON DELETE CASCADE: QUAN TRỌNG! Nếu sản phẩm bị xóa,
    -- tất cả ảnh liên quan cũng sẽ tự động bị xóa theo.
    CONSTRAINT FK_ProductImage_Product FOREIGN KEY ([ProductId])
        REFERENCES [dbo].[Products]([Id])
        ON DELETE CASCADE 
);