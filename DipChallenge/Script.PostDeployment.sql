/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF '$(LoadTestData)' = 'true'
	
	BEGIN

DELETE FROM CATEGORY;
DELETE FROM SEGMENT;
DELETE FROM PRODUCT;
DELETE FROM REGION;
DELETE FROM CUSTOMER;
DELETE FROM SHIPPING;
DELETE FROM ORDERED;

INSERT INTO CATEGORY (CatID, CatName) VALUES
(1, 'Furniture'),
(2, 'Office Supplies'),
(3, 'Technology');

INSERT INTO SEGMENT (SegID, SegName) VALUES
(1, 'Consumer'),
(2, 'Corporate'),
(3, 'Home Office');

INSERT INTO PRODUCT (ProdID, Description, UnitPrice, CatID) VALUES
('FUR-BO-10001798', 'Bush Somerset Collection Bookcase', 261.96, 1),
('FUR-CH-10000454', 'Mitel 5320 IP Phone VoIP phone', 731.94, 3),
('OFF-LA-10000240', 'Self-Adhesive Address Labels for Typewriters by Universal', 14.62, 2);

INSERT INTO REGION (Region) VALUES
('South'),
('Central'),
('West'),
('East'),
('North');

INSERT INTO CUSTOMER (CustID, FullName, Country, City, State, PostCode, SegID, Region) VALUES
('CG-12520', 'Claire Gute', 'United States', 'Henderson', 'Oklahoma', 42420, 1, 'Central'),
('DV-13045', 'Darrin Van Huff', 'United States', 'Los Angeles', 'California', 90036, 2, 'West'),
('SO-20335', 'Sean O''Donnell', 'United States', 'Fort Lauderdale', 'Florida', 33311, 1, 'South'),
('BH-11710', 'Brosina Hoffman', 'United States', 'Los Angeles', 'California', 90032, 3, 'West');

INSERT INTO SHIPPING (ShipMode) VALUES
('Second Class'),
('Standard Class'),
('First Class'),
('Overnight Express');

INSERT INTO ORDERED (OrderDate, Quantity, ShipDate, CustID, ProdID, ShipMode) VALUES
('2016-11-08', 2, '2016-11-11', 'CG-12520', 'FUR-BO-10001798', 'Second Class'),
('2016-06-12', 2, '2016-06-16', 'CG-12520', 'OFF-LA-10000240', 'Second Class'),
('2015-11-21', 2, '2015-11-26', 'DV-13045', 'OFF-LA-10000240', 'Second Class'),
('2014-10-11', 1, '2014-10-15', 'DV-13045', 'OFF-LA-10000240', 'Standard Class'),
('2016-11-12', 9, '2016-11-16', 'DV-13045', 'FUR-CH-10000454', 'Standard Class'),
('2016-09-02', 5, '2016-09-08', 'SO-20335', 'OFF-LA-10000240', 'Standard Class'),
('2017-08-25', 2, '2017-08-29', 'SO-20335', 'FUR-BO-10001798', 'Overnight Express'),
('2017-06-22', 2, '2017-06-26', 'SO-20335', 'FUR-CH-10000454', 'Standard Class'),
('2017-05-01', 3, '2017-05-02', 'SO-20335', 'FUR-BO-10001798', 'First Class');

END;