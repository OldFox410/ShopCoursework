CREATE TABLE SaleItems (
    Id INT IDENTITY(1,1) NOT NULL,
    SaleId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    PriceAtSale DECIMAL(18, 2) NOT NULL,
    CONSTRAINT PK_SaleItems PRIMARY KEY (Id),
    CONSTRAINT CK_SaleItems_Quantity CHECK (Quantity > 0),
    CONSTRAINT CK_SaleItems_Price CHECK (PriceAtSale >= 0),
    CONSTRAINT FK_SaleItems_Sales FOREIGN KEY (SaleId) 
        REFERENCES Sales(Id) ON DELETE CASCADE,
    CONSTRAINT FK_SaleItems_Products FOREIGN KEY (ProductId) 
        REFERENCES Products(Id)
);