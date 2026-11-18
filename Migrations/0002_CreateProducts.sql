CREATE TABLE Products (
    Id INT IDENTITY(1,1) NOT NULL,
    CategoryId INT NOT NULL,
    Name NVARCHAR(150) NOT NULL,
    Article NVARCHAR(50) NOT NULL,
    UnitPrice DECIMAL(18, 2) NOT NULL,
    StockQuantity INT NOT NULL CONSTRAINT DF_Products_Stock DEFAULT 0,
    CONSTRAINT PK_Products PRIMARY KEY (Id),
    CONSTRAINT UQ_Products_Article UNIQUE (Article),
    CONSTRAINT CK_Products_Price CHECK (UnitPrice >= 0),
    CONSTRAINT CK_Products_Stock CHECK (StockQuantity >= 0),
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) 
        REFERENCES Categories(Id)
);