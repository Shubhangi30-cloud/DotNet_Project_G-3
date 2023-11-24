Create Database ETSDB

CREATE TABLE Admins (
    admin_id INT PRIMARY KEY,
    admin_name VARCHAR(50) NOT NULL,
    password VARCHAR(100) NOT NULL
);

insert into Admins values (9845, 'Surbhi','Surbhi$123');
-------------------------------------------------------------------
create TABLE Customers (
    customer_id INT Identity (1,1),
    customer_name VARCHAR(100),
    phone_no INT UNIQUE,
    password VARCHAR(50),
    dob DATE,
    account_balance DECIMAL(10, 2) DEFAULT 0.0
);
create TABLE Vendors (
    vendor_id INT Identity(1,1),
    vendor_name VARCHAR(100),
    vendor_verification_card_id INT UNIQUE,
    phone_no INT UNIQUE,
    vendor_password VARCHAR(100)
);
insert into Vendors values('Shubhangi',4556,1454559008,'Shubhangi@123')

create TABLE Products (
    product_id INT Identity(1,1),
    vendor_id INT,
    brand_id INT,
    brand_name VARCHAR(255),
    brand_price DECIMAL(10, 2),
    availability BIT -- 0 or 1
);
CREATE VIEW Admin_View AS
SELECT * FROM Admins;

CREATE VIEW Customer_View AS
SELECT customer_id, customer_name, phone_no, dob, account_balance FROM Customers;

CREATE VIEW Vendor_View AS
SELECT vendor_id, vendor_name, phone_no FROM Vendors;

CREATE VIEW Product_View AS
SELECT product_id, brand_id, brand_name, brand_price, availability FROM Products;
