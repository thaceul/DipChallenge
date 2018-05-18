CREATE TABLE [dbo].[Customer]
(
	[CustID] NCHAR(8) NOT NULL , 
    [FullName] TEXT NOT NULL, 
    [Country] TEXT NOT NULL, 
    [City] TEXT NOT NULL, 
    [State] TEXT NOT NULL, 
    [PostCode] INT NOT NULL, 
    [SegID] INT NOT NULL, 
    [Region] NCHAR(7) NOT NULL, 
    CONSTRAINT [FK_Customer_Segment] FOREIGN KEY ([SegID]) REFERENCES [Segment]([SegID]), 
    CONSTRAINT [PK_Customer] PRIMARY KEY ([CustID]), 
    CONSTRAINT [FK_Customer_Region] FOREIGN KEY ([Region]) REFERENCES [Region]([Region]) 
)
