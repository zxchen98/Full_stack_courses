--1
SELECT Distinct City  
From Customers 
Where City in (Select Distinct City From Employees)

--2 Use sub-query
SELECT Distinct City  
From Customers 
Where City not in (Select Distinct City From Employees)

--2 Not Use sub-query
Select Distinct c.City 
From Customers C left join Employees e on c.City = e.City
Where e.City is null

--3
Select productID, Sum(Quantity) as quantities
From [Order Details]
Group by ProductID

--4
Select c.City, ISNULL(Sum(d.Quantity),0) as quantity
From Customers c left join orders o ON c.CustomerID = o.CustomerID left join [Order Details] d 
    on o.OrderID = d.OrderID
Group by C.City

--5 use union
Select distinct City From Customers
Except
Select City From Customers   
Group By City
Having Count(CustomerID) = 1
UNION
Select City From Customers   
Group By City
Having Count(CustomerID) = 0


--5 use sub-query
Select City  
From(
Select City, Count(CustomerID) as NumCount
From Customers  
Group by City) as temp  
Where temp.NumCount>=2

--6
Select c.City 
From Customers c join Orders o on c.CustomerID = o.CustomerID join [Order Details] d on d.OrderID = o.OrderID
Group by c.City
Having Count(distinct d.ProductID)>=2

--7
Select distinct c.CustomerID
From Customers c join Orders o on c.CustomerID = o.CustomerID
Where c.City<>o.ShipCity

--8
With BestProducts as (Select top 5 d.ProductID, AVG(d.UnitPrice*(1-d.discount)) as AveragePrice
From [Order Details] d  
Group by d.ProductID
Order by Sum(d.Quantity) desc)

Select ProductID, AveragePrice, City, TotalQuantity
From(
    select b.ProductID, b.AveragePrice, c.City, SUM(d.Quantity) as TotalQuantity, Rank() over(partition by b.ProductID order by SUM(d.Quantity) desc) as CityRank
    From BestProducts b join [Order Details] d on b.ProductID = d.ProductID join orders o on o.OrderID = d.OrderID
        join Customers c on c.CustomerID = o.CustomerID
    Group by b.ProductID, c.City, b.AveragePrice) as res
WHERE res.CityRank = 1

--9 use subquery
Select distinct e.City  
From Employees e 
Where e.City not in (Select c.City from Customers c join Orders o on c.CustomerID = o.CustomerID)

--9 not use subquery
Select distinct e.City
From Employees e left join Customers c on e.City = c.City left join Orders o on o.CustomerID = c.CustomerID
Where o.OrderID is null

--10


--11
Select distinct *
From xxx
