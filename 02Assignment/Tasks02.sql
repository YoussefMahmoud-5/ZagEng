-- Problem 1
--> 1068. Product Sales Analysis I

Select P.product_name , S.[year] , S.price
From Sales S join Product P 
On S.product_id = P.product_id



--> Problem 2
--> 1581. Customer Who Visited but Did Not Make Any Transactions

select V.customer_id , Count( * ) as count_no_trans
From Visits V Left Join Transactions T
on V.visit_id = T.visit_id
where T.transaction_id IS NULL
group by V.customer_id 



--> Problem 3 
--> 1378. Replace Employee ID With The Unique Identifier

select E.name , EU.unique_id 
From Employees E left join EmployeeUNI EU
On E.id = EU.id


--> Problem 4
--> 197. Rising Temperature

select WB.id
From Weather WB Join Weather WA
on WB.recordDate = DATEADD( DAY , 1 , WA.recordDate ) and WB.temperature > WA.temperature



--> Problem 5
/* 
Employee Department Match with NULL Handling
Find all employees and their department names.
If an employee is not assigned to any department,
show "Unassigned" instead of NULL
*/

select E.empName , ISNULL( D.deptName ,'Unassigned')
From Employee E left join Department D 
On E.deptId = D.deptId



--> Problem 6


Select P.productName , s.supplierName
From Products P left Join Suppliers S
on P.supplierId = S.supplierId
Where P.productName like '%Phone_%' OR S.supplierName IS NULL


--> Problem 7 

select Concat(C.first_name+' '+C.last_name) as full_name , O.orderId , O.amount
from Customers C full join Orders O
on C.customerId = O.customerId


/* ============================================================================== 
   ADVANCED JOINS
=============================================================================== */

/* Get all customers who haven't placed any order */
Select *
From Customers C Left Join Orders O
On C.id =O.customer_id
Where O.customer_id Is Null

/* Get all orders without matching customers */
Select *
From Customers C Right Join Orders O
On C.id =O.customer_id
Where C.id Is Null


-- Alternative to RIGHT ANTI JOIN using LEFT JOIN
/* Get all orders without matching customers */    

Select *
From Orders O Left Join Customers C
On C.id =O.customer_id
Where C.id Is Null

/* Get all customers along with their orders, 
   but only for customers who have placed an order */

Select *
From Customers C Join Orders O
On C.id =O.customer_id

/* Find customers without orders and orders without customers */
Select *
From Customers C  Full Join Orders O
On C.id =O.customer_id
Where C.id Is Null Or O.customer_id Is Null

/* Generate all possible combinations of customers and orders */
Select *
From Customers Cross Join Orders


/* ============================================================================== 
   MULTIPLE TABLE JOINS (4 Tables)
=============================================================================== */

/* Task: Using SalesDB, Retrieve a list of all orders, 
   along with the related customer, product, 
   and employee details. For each order, display:
   - Order ID
   - Customer's name
   - Product name
   - Sales amount
   - Product price
   - Salesperson's name */
   Use SalesDB


Select O.OrderID,C.FirstName + ' ' + IsNull(C.LastName, '') As CustomerName,
    P.Product As ProductName,O.Sales As SalesAmount,
    P.Price As ProductPrice,E.FirstName + ' ' + IsNull(E.LastName, '') As SalesPersonName
From Sales.Orders O Left Join Sales.Customers C 
            On O.CustomerID = C.CustomerID 
Left Join Sales.Products P 
            On O.ProductID = P.ProductID
Left Join Sales.Employees E 
            On O.SalesPersonID = E.EmployeeID