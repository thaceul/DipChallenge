CREATE TABLE [dbo].[Ordered]
(
	[OrderDate] DATE NOT NULL , 
    [Quantity] INT NOT NULL, 
    [ShipDate] DATE NOT NULL, 
    [CustID] NCHAR(8) NOT NULL, 
    [ProdID] NCHAR(15) NOT NULL, 
    [ShipMode] NCHAR(17) NOT NULL, 

    CONSTRAINT [FK_Ordered_Product] FOREIGN KEY ([ProdID]) REFERENCES [Product]([ProdID]), 
    CONSTRAINT [FK_Ordered_Shipping] FOREIGN KEY ([ShipMode]) REFERENCES [Shipping]([ShipMode]), 
    CONSTRAINT [PK_Ordered] PRIMARY KEY ([OrderDate]), 
    CONSTRAINT [FK_Ordered_Customer] FOREIGN KEY ([CustID]) REFERENCES [Customer]([CustID]), 
)
