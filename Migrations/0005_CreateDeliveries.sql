CREATE TABLE Deliveries (
    Id INT IDENTITY(1,1) NOT NULL,
    SupplierId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    PurchasePrice DECIMAL(18, 2) NOT NULL,
    DeliveryDate DATETIME2 NOT NULL CONSTRAINT DF_Deliveries_Date DEFAULT SYSDATETIME(),
    CONSTRAINT PK_Deliveries PRIMARY KEY (Id),
    CONSTRAINT CK_Deliveries_Quantity CHECK (Quantity > 0),
    CONSTRAINT CK_Deliveries_Price CHECK (PurchasePrice >= 0),
    CONSTRAINT FK_Deliveries_Suppliers FOREIGN KEY (SupplierId) 
        REFERENCES Suppliers(Id),
    CONSTRAINT FK_Deliveries_Products FOREIGN KEY (ProductId) 
        REFERENCES Products(Id)
);