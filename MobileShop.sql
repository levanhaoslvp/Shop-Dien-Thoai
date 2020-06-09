--USE master
--alter database MOBILESHOP2 set single_user with rollback immediate
--drop database MOBILESHOP2

CREATE DATABASE MOBILESHOP2
GO

USE MOBILESHOP2
GO

CREATE TABLE [CATEGORY]
(
    CategoryID INT PRIMARY KEY ,
    CategoryName NVARCHAR(250) UNIQUE NOT NULL,
    MetaKeyword NVARCHAR(50),
    CreatedDate DATETIME DEFAULT GETDATE()
)
GO

GO
CREATE TABLE [PRODUCT]
(
    ProductID INT PRIMARY KEY ,
    ProductName NVARCHAR(250) NOT NULL,
    ProductPrice DECIMAL(18, 0) NOT NULL,
	PromotionPrice DECIMAL(18, 0) DEFAULT 0,
	ProductDescription NVARCHAR(MAX),
    Rating INT CHECK (RATING >=0 AND RATING <= 5),
    ShowImage NVARCHAR(MAX) DEFAULT N'',   
    ProductStock INT DEFAULT 1,
    MetaKeyword NVARCHAR(250),
    ProductStatus BIT,
    CreatedDate DATETIME DEFAULT GETDATE(),
    CategoryID int CONSTRAINT fk_p_cgid FOREIGN KEY (CategoryID) REFERENCES [CATEGORY](CategoryID) ON DELETE CASCADE NOT NULL
)
GO

CREATE TABLE [PRODUCTIMAGE]
(
    ImageID int PRIMARY KEY,
    DetailImage_1 NVARCHAR(MAX) DEFAULT N'',
    DetailImage_2 NVARCHAR(MAX) DEFAULT N'',
    DetailImage_3 NVARCHAR(MAX) DEFAULT N'',
	 ProductID int CONSTRAINT fk_pi_pdid FOREIGN KEY (ProductID) REFERENCES [PRODUCT](ProductID) ON DELETE CASCADE
)


CREATE TABLE [OPTION](
OptionID int PRIMARY KEY,
OptionName nvarchar(255)
)
GO 

CREATE TABLE [PRODUCTDETAIL](
	DetailID int PRIMARY KEY IDENTITY(1,1),
	 ProductID int CONSTRAINT fk_pd_pdid FOREIGN KEY (ProductID) REFERENCES [PRODUCT](ProductID) ON DELETE CASCADE,
	OptionID int REFERENCES [OPTION](OptionID)
)
CREATE TABLE [CUSTOMER]
(
    CustomerID INT PRIMARY KEY IDENTITY(1, 1),
    CustomerUsername NVARCHAR(250) UNIQUE NOT NULL,
    CustomerPassword NVARCHAR(250) NOT NULL,
    CustomerEmail NVARCHAR(250),
    CustomerName NVARCHAR(250) NOT NULL,
    CustomerPhone NVARCHAR(20),
    CustomerAdress NVARCHAR(250),
    CreatedDate DATETIME DEFAULT GETDATE()
)
GO

CREATE TABLE [ORDERSTATUS]
(
    StatusID INT PRIMARY KEY IDENTITY(1, 1),
    StatusName NVARCHAR(255),
    CreatedDate DATETIME DEFAULT GETDATE()
)
GO

CREATE TABLE [ORDER]
(
    OrderID INT PRIMARY KEY IDENTITY(1, 1),
    Total DECIMAL(18, 2),
    OrderDate DATETIME DEFAULT GETDATE(),
    DeliveryDate DATETIME,
	OrderStatusID INT CONSTRAINT fk_od_stid FOREIGN KEY (OrderStatusID) REFERENCES [ORDERSTATUS](StatusID),
    CustomerID INT CONSTRAINT fk_od_csid FOREIGN KEY (CustomerID) REFERENCES [CUSTOMER](CustomerID) ON DELETE CASCADE
)
GO

CREATE TABLE [ORDERDETAIL]
(
    DetailID INT PRIMARY KEY IDENTITY(1, 1) ,

    Quantity INT,
    OptionID int REFERENCES [OPTION](OptionID),
   OrderID INT CONSTRAINT fk_od_odid FOREIGN KEY (OrderID) REFERENCES [ORDER](OrderID) ON DELETE CASCADE,
    ProductID int  CONSTRAINT fk_od_pdid FOREIGN KEY (ProductID) REFERENCES [PRODUCT](ProductID) ON DELETE CASCADE
)
GO

CREATE TABLE [USER]
(
    UserId INT PRIMARY KEY IDENTITY(1,1),
    UserUsername NVARCHAR(250) UNIQUE NOT NULL,
    UserPassword NVARCHAR(250) NOT NULL,
    UserName NVARCHAR(250),

    CreatedDate DATETIME
)
GO

INSERT MOBILESHOP2.dbo.CATEGORY
VALUES
(
    1,
    N'I phone', -- CategoryName - NVARCHAR
    N'i-phone', -- MetaKeyword - NVARCHAR
    '2020-04-30 18:41:38' -- CreatedDate - DATETIME
)
INSERT MOBILESHOP2.dbo.CATEGORY
VALUES
(
    2,
    N'Sam Sung', -- CategoryName - NVARCHAR
    N'sam-sung', -- MetaKeyword - NVARCHAR
    '2020-04-30 18:41:38' -- CreatedDate - DATETIME
)

INSERT MOBILESHOP2.dbo.CATEGORY
VALUES
(
    3,
    N'Xiaomi', -- CategoryName - NVARCHAR
    N'xiaomi', -- MetaKeyword - NVARCHAR
    '2020-04-30 18:41:38' -- CreatedDate - DATETIME
)

INSERT dbo.PRODUCT
(
    ProductID,
    ProductName,
    ProductPrice,
    PromotionPrice,
    ProductDescription,
    Rating,
    ShowImage,
    ProductStock,
    MetaKeyword,
    ProductStatus,
    CreatedDate,
    CategoryID
)
VALUES
(
    1, -- ProductID - INT
    N'I phone X', -- ProductName - NVARCHAR
    700, -- ProductPrice - DECIMAL
    600, -- PromotionPrice - DECIMAL
    N'Đẹp, Sịn', -- ProductDescription - NVARCHAR
    
    0, -- Rating - INT
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- ShowImage - NVARCHAR
    50, -- ProductStock - INT
    N'i-phone-x', -- MetaKeyword - NVARCHAR
    1, -- ProductStatus - BIT
    '2020-04-30 18:42:08', -- CreatedDate - DATETIME
    1 -- CategoryID - INT
),
(
    2, -- ProductID - INT
    N'I phone 7', -- ProductName - NVARCHAR
    900, -- ProductPrice - DECIMAL
    800, -- PromotionPrice - DECIMAL
    N'Đắt', -- ProductDescription - NVARCHAR
    
    0, -- Rating - INT
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- ShowImage - NVARCHAR
    50, -- ProductStock - INT
    N'i-phone-7', -- MetaKeyword - NVARCHAR
    1, -- ProductStatus - BIT
    '2020-04-30 18:42:08', -- CreatedDate - DATETIME
    1 -- CategoryID - INT
),
(
    3, -- ProductID - INT
    N'Sam Sung', -- ProductName - NVARCHAR
    500, -- ProductPrice - DECIMAL
    400, -- PromotionPrice - DECIMAL
    N'Ngon', -- ProductDescription - NVARCHAR
    
    0, -- Rating - INT
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- ShowImage - NVARCHAR
    50, -- ProductStock - INT
    N'sam-sung', -- MetaKeyword - NVARCHAR
    1, -- ProductStatus - BIT
    '2020-04-30 18:42:08', -- CreatedDate - DATETIME
    2 -- CategoryID - INT
),
(
    4, -- ProductID - INT
    N'Xiaomi', -- ProductName - NVARCHAR
    500, -- ProductPrice - DECIMAL
    400, -- PromotionPrice - DECIMAL
    N'Ngon rẻ', -- ProductDescription - NVARCHAR
    
    0, -- Rating - INT
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- ShowImage - NVARCHAR
    50, -- ProductStock - INT
    N'xiaomi', -- MetaKeyword - NVARCHAR
    1, -- ProductStatus - BIT
    '2020-04-30 18:42:08', -- CreatedDate - DATETIME
    3 -- CategoryID - INT
)

INSERT dbo.[OPTION]
(
   OptionID,
    OptionName
)
VALUES
(
   1,
    N'64GB' -- OptionName - nvarchar
),
(
   2,
    N'128GB' -- OptionName - nvarchar
),
(
    3,
    N'256GB' -- OptionName - nvarchar
)

INSERT dbo.PRODUCTDETAIL
(
    --DetailID - column value is auto-generated
    ProductID,
    OptionID
)
VALUES
(
    -- DetailID - int
    1, -- ProductID - int
    1 -- OptionID - int
),
(
    -- DetailID - int
    2, -- ProductID - int
    2 -- OptionID - int
),
(
    -- DetailID - int
    3, -- ProductID - int
    3 -- OptionID - int
),
(
    -- DetailID - int
    4, -- ProductID - int
    3 -- OptionID - int
)
INSERT INTO [ORDERSTATUS]
VALUES
    (N'Đang xử lý', GETDATE()),
    (N'Đang giao hàng', GETDATE()),
    (N'Đã giao hàng', GETDATE()),
    (N'Hàng có lỗi', GETDATE()),
    (N'Đã hủy', GETDATE())
GO
INSERT dbo.PRODUCTIMAGE
(
    ImageID,
    DetailImage_1,
    DetailImage_2,
    DetailImage_3,
    ProductID
)
VALUES
(
    1, -- ImageID - int
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- DetailImage_1 - NVARCHAR
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- DetailImage_2 - NVARCHAR
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- DetailImage_3 - NVARCHAR
    1 -- ProductID - int
),
(
    2, -- ImageID - int
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- DetailImage_1 - NVARCHAR
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- DetailImage_2 - NVARCHAR
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- DetailImage_3 - NVARCHAR
    2 -- ProductID - int
),
(
    3, -- ImageID - int
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- DetailImage_1 - NVARCHAR
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- DetailImage_2 - NVARCHAR
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- DetailImage_3 - NVARCHAR
    3 -- ProductID - int
),
(
    4, -- ImageID - int
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- DetailImage_1 - NVARCHAR
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- DetailImage_2 - NVARCHAR
    N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x400.jpg', -- DetailImage_3 - NVARCHAR
    4 -- ProductID - int
)
SELECT o.OptionName,p.ProductPrice
FROM dbo.PRODUCT p,PRODUCTDETAIL p2, dbo.[OPTION] o
WHERE p.ProductID=p2.ProductID AND p2.OptionID=o.OptionID AND p.ProductName = 'I phone X'

SELECT * FROM dbo.CATEGORY c

SELECT p.* FROM dbo.PRODUCT  p
SELECT o.* FROM dbo.[OPTION] o
SELECT p.* FROM dbo.PRODUCTDETAIL p
SELECT p.* FROM dbo.PRODUCTIMAGE p