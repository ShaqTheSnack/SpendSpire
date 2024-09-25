-- THIS IS FOR CREATING THE TABLE
CREATE TABLE PersonalBudgetData (
    ID INT PRIMARY KEY CHECK (ID = 1),
    Income INT,
    Expenses INT,
    Remaining INT,
    RentOrMortgage INT,
    Groceries INT,
    Utilities INT,
    Transportation INT,
    LoanPayments INT,
    Savings INT,
    Health INT,
    Entertainment INT,
    PersonalCare INT,
    Insurance INT,
    Education INT,
    Childcare INT,
    DiningOut INT,
    Subscriptions INT,
    HomeMaintenance INT,
    Pets INT,
    Others INT,
    RandomData INT
);




-- THIS IS TO POPULATE DATA VALUES TO 0 AND ID TO 1
INSERT INTO PersonalBudgetData (
    ID, Income, Expenses, Remaining, RentOrMortgage, Groceries, Utilities, Transportation, 
    LoanPayments, Savings, Health, Entertainment, PersonalCare, Insurance, Education, 
    Childcare, DiningOut, Subscriptions, HomeMaintenance, Pets, Others, RandomData
) 
VALUES (
    1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
);



-- THIS IS FOR DROP TABLE
DROP TABLE PersonalBudgetData



-- THIS IS FOR VIEWING ALL DATA IN THE TABLE
SELECT * FROM PersonalBudgetData



-- THIS IS FOR UPDATING COLUMNS IN THE TABLE
UPDATE PersonalBudgetData
SET Income = 0;
