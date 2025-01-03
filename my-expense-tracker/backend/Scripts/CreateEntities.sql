CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CreatedBy INT NOT NULL,
    CreatedAt DATETIME NOT NULL,
    LastModifiedBy INT NOT NULL,
    LastModifiedAt DATETIME NOT NULL
);

CREATE TABLE ExpenseCategories (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    CreatedBy INT NOT NULL,
    CreatedAt DATETIME NOT NULL,
    LastModifiedBy INT NOT NULL,
    LastModifiedAt DATETIME NOT NULL
);

CREATE TABLE Expenses (
    Id INT PRIMARY KEY IDENTITY,
    Amount DECIMAL(18, 2) NOT NULL,
    Description NVARCHAR(255),
    Date DATETIME NOT NULL,
    CategoryId INT NOT NULL,
    CreatedBy INT NOT NULL,
    CreatedAt DATETIME NOT NULL,
    LastModifiedBy INT NOT NULL,
    LastModifiedAt DATETIME NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES ExpenseCategories(Id)
);
