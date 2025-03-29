CREATE TABLE Category (
    Id INT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Active BOOLEAN NOT NULL,
    CreatedAt TIMESTAMP NOT NULL,
    UpdatedAt TIMESTAMP NOT NULL
);

CREATE TABLE Product (
    Id INT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Brand VARCHAR(255),
    Model VARCHAR(255),
    Price DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    Active BOOLEAN NOT NULL,
    CreatedAt TIMESTAMP NOT NULL,
    UpdatedAt TIMESTAMP NOT NULL,
    CategoryId INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Category(Id)
);
