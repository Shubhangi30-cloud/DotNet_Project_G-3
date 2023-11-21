Create Database ETradingSystemDB;
use ETradingSystemDB;

CREATE TABLE Admins (
    admin_id INT PRIMARY KEY,
    admin_name VARCHAR(50) NOT NULL,
    password VARCHAR(100) NOT NULL
);

CREATE TABLE Customer (
    customer_id INT ,
    customer_name VARCHAR(100),
    password VARCHAR(50),
    dob_date DATE
);

CREATE TABLE vendor (
    vendor_Id INT IDENTITY,
    vendor_password VARCHAR(100),
	vendor_name VARCHAR(100),
	address VARCHAR(100),
	Phone_no int,
	Email_id VARCHAR(100),
);

CREATE TABLE product (
    vendor_id INT ,
    brand_id INT,
    brand_name VARCHAR(255),
    brand_price DECIMAL(10, 2) ,
	availability BIT --0 OR 1
);
