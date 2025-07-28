
-- データベース作成
CREATE DATABASE OliveShopDB2;
GO
USE OliveShopDB2;
GO

-- 管理者テーブル
CREATE TABLE Admins (
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100)
);
GO

-- 商品カテゴリ
CREATE TABLE ProductCategories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    TaxRate DECIMAL(4,2) NOT NULL DEFAULT 10.00
);
GO

-- 商品テーブル
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    CategoryID INT NOT NULL,
    AlertThreshold INT,
    Description NVARCHAR(MAX),
    IsPublished BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (CategoryID) REFERENCES ProductCategories(CategoryID)
);
GO

-- 顧客テーブル
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(50) NOT NULL,
    Address NVARCHAR(MAX) NOT NULL,
    RegisteredAt DATETIME NOT NULL,
    IsEnable BIT NOT NULL DEFAULT 1
);
GO

-- 発注予約（受注ヘッダー）
CREATE TABLE OrderReservations (
    ReservationID NVARCHAR(50) PRIMARY KEY,
    ReservationDateTime DATETIME NOT NULL,
    CustomerID INT NOT NULL,
    TotalAmount DECIMAL(10,2),
    ShippingAddress NVARCHAR(MAX),
    PaymentMethod NVARCHAR(50),
    Status NVARCHAR(50) NOT NULL,
    ImportedDateTime DATETIME,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
GO

-- 受注明細
CREATE TABLE OrderReservationItems (
    ItemID INT IDENTITY(1,1) PRIMARY KEY,
    ReservationID NVARCHAR(50) NOT NULL,
    ProductID INT NOT NULL,
    ProductName NVARCHAR(255) NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    TaxRate DECIMAL(4,2) NOT NULL,
    FOREIGN KEY (ReservationID) REFERENCES OrderReservations(ReservationID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO

-- ステータス履歴
CREATE TABLE OrderStatusHistory (
    HistoryID INT IDENTITY(1,1) PRIMARY KEY,
    ReservationID NVARCHAR(50) NOT NULL,
    StatusFrom NVARCHAR(50) NOT NULL,
    StatusTo NVARCHAR(50) NOT NULL,
    ChangeDateTime DATETIME NOT NULL,
    ChangedByAdminID INT NOT NULL,
    FOREIGN KEY (ReservationID) REFERENCES OrderReservations(ReservationID),
    FOREIGN KEY (ChangedByAdminID) REFERENCES Admins(AdminID)
);
GO

-- 在庫アラートログ
CREATE TABLE AlertLogs (
    AlertID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    DetectedAt DATETIME NOT NULL,
    StockAtAlert INT NOT NULL,
    IsResolved BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO