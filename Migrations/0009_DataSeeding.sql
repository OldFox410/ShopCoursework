-- 1. Категории
IF NOT EXISTS (SELECT 1 FROM Categories)
BEGIN
    INSERT INTO Categories (Name) VALUES 
    (N'Смартфоны и гаджеты'),
    (N'Бытовая техника'),
    (N'Продукты питания'),
    (N'Инструменты');
END

-- 2. Товары
IF NOT EXISTS (SELECT 1 FROM Products)
BEGIN
    DECLARE @TechCatId INT = (SELECT Id FROM Categories WHERE Name = N'Смартфоны и гаджеты');
    DECLARE @HomeTechCatId INT = (SELECT Id FROM Categories WHERE Name = N'Бытовая техника');
    DECLARE @FoodCatId INT = (SELECT Id FROM Categories WHERE Name = N'Продукты питания');

    INSERT INTO Products (CategoryId, Name, Article, UnitPrice, StockQuantity) VALUES 
    (@TechCatId, N'Смартфон X-Phone 12', 'ART-PH-001', 45000.00, 15),
    (@TechCatId, N'Беспроводные наушники Pods', 'ART-ACC-002', 7500.00, 30),
    (@HomeTechCatId, N'Робот-пылесос CleanBot', 'ART-HM-003', 24999.50, 8),
    (@FoodCatId, N'Кофе в зернах (1 кг)', 'ART-FD-004', 1200.00, 50);
END

IF NOT EXISTS (SELECT 1 FROM Employees)
BEGIN
    INSERT INTO Employees (LastName, FirstName, MiddleName, Position, Phone, HireDate, HasChildren) VALUES 
    (N'Иванов', N'Иван', N'Иванович', N'Старший продавец', '+79991112233', '2023-03-15', 1),
    (N'Петрова', N'Анна', N'Сергеевна', N'Кассир', '+79992223344', '2024-01-10', 0),
    (N'Смирнов', N' Алексей', N'Владимирович', N'Менеджер по закупкам', '+79993334455', '2022-09-01', 1),
    (N'Кузнецова', N'Ольга', NULL, N'Администратор', '+79994445566', '2021-06-20', 0);
END

IF NOT EXISTS (SELECT 1 FROM Suppliers)
BEGIN
    INSERT INTO Suppliers (CompanyName, ContactPerson, Phone, Email, Address) VALUES 
    (N'ООО «ТехноПром»', N'Виктор Баринов', '+74951234567', 'info@technoprom.ru', N'г. Москва, ул. Промышленная, 10'),
    (N'ИП «Вкусные Решения»', N'Марина Цветаева', '+74957654321', 'vros@mail.ru', N'г. Санкт-Петербург, пр. Лесной, 45');
END

IF NOT EXISTS (SELECT 1 FROM Deliveries)
BEGIN
    DECLARE @Supplier1 INT = (SELECT TOP 1 Id FROM Suppliers WHERE CompanyName LIKE N'%ТехноПром%');
    DECLARE @Product1 INT = (SELECT TOP 1 Id FROM Products WHERE Article = 'ART-PH-001');
    DECLARE @Product2 INT = (SELECT TOP 1 Id FROM Products WHERE Article = 'ART-HM-003');

    INSERT INTO Deliveries (SupplierId, ProductId, Quantity, PurchasePrice, DeliveryDate) VALUES 
    (@Supplier1, @Product1, 20, 38000.00, '2026-01-10 10:00:00'),
    (@Supplier1, @Product2, 10, 20000.00, '2026-02-05 14:30:00');
END

IF NOT EXISTS (SELECT 1 FROM Sales)
BEGIN
    DECLARE @EmpId INT = (SELECT TOP 1 Id FROM Employees WHERE LastName = N'Иванов');
    DECLARE @ProdPhone INT = (SELECT TOP 1 Id FROM Products WHERE Article = 'ART-PH-001');
    DECLARE @ProdPods INT = (SELECT TOP 1 Id FROM Products WHERE Article = 'ART-ACC-002');
    DECLARE @ProdCoffee INT = (SELECT TOP 1 Id FROM Products WHERE Article = 'ART-FD-004');

    INSERT INTO Sales (EmployeeId, SaleDate, TotalAmount) 
    VALUES (@EmpId, '2026-10-15 12:30:00', 52500.00);
    
    DECLARE @SaleId1 INT = SCOPE_IDENTITY();

    INSERT INTO SaleItems (SaleId, ProductId, Quantity, PriceAtSale) VALUES 
    (@SaleId1, @ProdPhone, 1, 45000.00),
    (@SaleId1, @ProdPods, 1, 7500.00);

    INSERT INTO Sales (EmployeeId, SaleDate, TotalAmount) 
    VALUES (@EmpId, '2026-10-18 16:45:00', 2400.00);

    DECLARE @SaleId2 INT = SCOPE_IDENTITY();

    INSERT INTO SaleItems (SaleId, ProductId, Quantity, PriceAtSale) VALUES 
    (@SaleId2, @ProdCoffee, 2, 1200.00);
END