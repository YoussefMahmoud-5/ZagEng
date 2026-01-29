-- Problem 01

Select * 
From Cinema 
Where id % 2 = 1 and description != 'boring'
order by rating desc

-- Problem 02

Select P.project_id , Round(avg(E.experience_years),2) as average_years 
From Project P JOIN Employee E 
on E.employee_id = P.employee_id
Group by P.project_id

-- Problem 03
Select Date_FORMAT(trans_date, '%Y-%m') as 'month' ,
country ,
count(id) as trans_count ,
count(case when  state = 'approved' then 1 End ) as approved_count ,
sum(amount) trans_total_amount , 
sum(case when state = 'approved' then amount Else 0 End ) as approved_total_amount
From Transactions 
group by month , country

-- Problem 04

Select teacher_id , count(distinct subject_id) cnt
From Teacher 
group by teacher_id

-- Problem 05

Select employee_id
From Employees 
where manager_id is not null and manager_id not in (Select employee_id from Employees) and salary < 30000
order by employee_id
-----------------------------------------------------------------------
Select E.employee_id
From Employees E left join Employees M
on M.employee_id = E.manager_id
where E.salary < 30000 and E.manager_id is not null and M.employee_id is null
order by E.employee_id

-- Problem 06 

Select case when id % 2 = 0 then id - 1 
            when id % 2 = 1 and id + 1 in (Select id from Seat ) then id + 1
            else id end as id ,
            student 
From Seat 
order by id 

-- Problem 07

Select  employee_id , department_id
From Employee 
Where primary_flag = 'Y'
Or employee_id in (Select employee_id 
                   From Employee 
                   group by employee_id 
                   having count(employee_id) = 1)

-- Problem 08
Create NonClustered Index Ix_ApplogsFastsQuery
on AppLogs(service_name , created_at desc)
include (status_code)

-- Problem 09

-- query is slow because we select column in select statement not exist in indexs 
-- We Will Use Covering Index 
Create NonClustered Index Ix_FasterQuary
On Orders(order_date)
Include(order_id , customer_id , total_amount)


-- Problem 10

Create Or Alter Procedure sp_ApplyCategoryDiscount
@CatId int , @DiscountPercent Decimal(10,2)
as
Begin 
Update Products
Set price = Case 
            price - (price * @DiscountPercent/100) < min_price then min_price 
            Else (price * @DiscountPercent/100)
            End
Where category_id = @CatId
End

-- Problem 11

-- First sol
Create or Alter View V_VipCustomers 
As 
    Select name , email , sum(O.total_amount) as total_spent 
    from Customers C join Orders O 
    on C.customer_id = O.customer_id
    Group by C.name , C.email
    having sum(O.total_amount) > 5000

-- Second sol 

Create or Alter View V_VipCustomers 
As 
    Select name , email , sum(total_amount) as total_spent 
    from Customers 
    Group by name , email
    having sum(total_amount) > 5000

-- use 
Select * 
From V_VipCustomers
order by total_spent desc

