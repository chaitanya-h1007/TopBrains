
CREATE TABLE Employeee (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    Department VARCHAR(50),
    Salary DECIMAL(10, 2),
    HireDate DATE
);

INSERT INTO Employee (FirstName, LastName, Email, Department, Salary, HireDate)
VALUES
('Rahul', 'Sharma', 'rahul.sharma@example.com', 'IT', 55000.00, '2024-01-15'),
('Anita', 'Verma', 'anita.verma@example.com', 'HR', 48000.00, '2023-08-10'),
('Vikas', 'Mehta', 'vikas.mehta@example.com', 'Finance', 62000.00, '2022-11-05'),
('Priya', 'Singh', 'priya.singh@example.com', 'Marketing', 50000.00, '2024-03-20'),
('Amit', 'Patel', 'amit.patel@example.com', 'IT', 70000.00, '2021-06-12'),
('Neha', 'Gupta', 'neha.gupta@example.com', 'HR', 46000.00, '2023-02-18'),
('Suresh', 'Reddy', 'suresh.reddy@example.com', 'Operations', 52000.00, '2022-09-30'),
('Kavita', 'Nair', 'kavita.nair@example.com', 'Finance', 58000.00, '2021-12-01'),
('Rohit', 'Agarwal', 'rohit.agarwal@example.com', 'IT', 65000.00, '2023-05-14'),
('Pooja', 'Mishra', 'pooja.mishra@example.com', 'Marketing', 49000.00, '2024-04-05'),
('Arjun', 'Kumar', 'arjun.kumar@example.com', 'IT', 72000.00, '2020-10-21'),
('Sneha', 'Iyer', 'sneha.iyer@example.com', 'HR', 51000.00, '2022-07-19'),
('Manish', 'Chopra', 'manish.chopra@example.com', 'Sales', 54000.00, '2023-01-11'),
('Deepak', 'Yadav', 'deepak.yadav@example.com', 'Operations', 50000.00, '2024-02-08'),
('Ritu', 'Bansal', 'ritu.bansal@example.com', 'Finance', 60000.00, '2021-04-17');


--WHERE 
Select * 
From Employee Where Department = 'IT'

--Pattern Matching using the LIKE Operator


Select FirstName as Name
From Employee 
Where (FirstName Like 'R%' )  OR FirstName Like '%Y%' OR FirstName Like '%S';


SELECT * 
FROM Employee;


-- Highest salary

Select Top 1 * 
From Employee
Order by Salary Desc;


--Second Hihgest 
Select  Top 1 * from
(Select Top 2 *
From Employee
Order by Salary Desc)
 TT Order by tt.Salary ;
