CREATE TABLE [dbo].[Product]
(
	[ProdID] NCHAR(15) NOT NULL , 
    [Description] TEXT NOT NULL, 
    [UnitPrice] MONEY NOT NULL, 
    [CatID] INT NOT NULL, 
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CatID]) REFERENCES [Category]([CatID]), 
    CONSTRAINT [PK_Product] PRIMARY KEY ([ProdID]) 

)
