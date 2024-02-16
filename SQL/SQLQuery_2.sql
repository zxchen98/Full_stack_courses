--1
Select Count(ProductID) as totalCount
FROM Production.Product

--2
Select Count(ProductID) as ProductCount
FROM Production.Product
WHERE ProductSubcategoryID is not NULL

--3
Select ProductSubcategoryID, Count(ProductID) as CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID is not NULL
Group by ProductSubcategoryID

--4
Select Count(ProductID) as ProductCount
FROM Production.Product
WHERE ProductSubcategoryID is NULL

--5
Select SUM(Quantity)
From Production.ProductInventory

--6
Select ProductID, SUM(Quantity) as TheSum
From Production.ProductInventory
Where LocationID=40
GROUP BY ProductID
Having SUM(Quantity)<100

--7
Select Shelf, ProductID, SUM(Quantity) as TheSum
From Production.ProductInventory
Where LocationID=40
GROUP BY Shelf, ProductID
Having SUM(Quantity)<100

--8
Select AVG(Quantity) as AvgCount
From Production.ProductInventory
Where LocationID=10

--9
Select ProductID, Shelf, AVG(Quantity) as TheAvg
From Production.ProductInventory
GROUP BY Shelf, ProductID

--10
Select ProductID, Shelf, AVG(Quantity) as TheAvg
From Production.ProductInventory
Where Shelf is not Null
GROUP BY Shelf, ProductID

--11
Select Color, Class, Count(ProductID) TheCount, AVG(ListPrice) AvgPrice
From Production.Product
Where Color is not Null and Class is not NULL
Group by Color, Class

--12
Select c.Name Country, p.Name Province
from Person.CountryRegion c join Person.StateProvince p on c.CountryRegionCode = p.CountryRegionCode

--13
Select c.Name Country, p.Name Province
From Person.CountryRegion c join Person.StateProvince p on c.CountryRegionCode = p.CountryRegionCode
Where  c.Name in ('Germany','Canada')

--14
Select Distinct p.ProductID, p.ProductName
From dbo.Products p
Where p.ProductID in (
    Select d.productID
    From dbo.[Order Details] d join dbo.Orders o on d.OrderID = o.OrderID
    Where o.OrderDate >= DateADD(YEAR,-26,GETDATE()) 
)

--15
Select top 5 ShipPostalCode
From dbo.Orders
Group by ShipPostalCode
Order by Count(orderID) desc

--16
Select top 5 ShipPostalCode
From dbo.Orders
Where OrderDate >= DateADD(YEAR,-26,GETDATE()) 
Group by ShipPostalCode
Order by Count(orderID) desc

--17
Select City, Count(CustomerID) CustomerCount
From dbo.Customers
Group by City

--18
SELECT temp.City, temp.CustomerCount
FROM(
    Select City, Count(CustomerID) CustomerCount
    From dbo.Customers
    Group by City) as temp
Where temp.CustomerCount>=2

--19
Select distinct c.ContactName
From dbo.Customers c JOIN dbo.Orders o ON c.CustomerID = O.CustomerID
Where o.OrderDate > '1998-01-01'

--20
Select distinct c.ContactName
From dbo.Customers c JOIN dbo.Orders o ON c.CustomerID = O.CustomerID
Where o.OrderDate in (Select MAX(OrderDate) from dbo.Orders)

--21
Select c.ContactName, ISNULL(SUM(d.ProductID),0) AS OrderCounts
From dbo.Customers c left join dbo.Orders o on c.CustomerID = o.CustomerID left join dbo.[Order Details] d on o.OrderID = d.OrderID
Group by c.ContactName

--22
Select ContactName, OrderCounts
From(
   Select c.ContactName, ISNULL(SUM(d.ProductID),0) AS OrderCounts
   From dbo.Customers c left join dbo.Orders o on c.CustomerID = o.CustomerID left join dbo.[Order Details] d on o.OrderID = d.OrderID
   Group by c.ContactName) as temp 
Where OrderCounts > 100

--23
SELECT distinct sp.CompanyName, sh.CompanyName
From dbo.Orders o join dbo.[Order Details] d on o.OrderID = d.OrderID join dbo.Products p on d.ProductID=p.ProductID
    join dbo.Suppliers sp on p.SupplierID = sp.SupplierID join dbo.Shippers sh on o.ShipVia = sh.ShipperID

--24
Select o.OrderDate, p.ProductName
From dbo.Orders o join dbo.[Order Details] d on o.OrderID = D.OrderID JOIN Products p on d.ProductID = p.ProductID

--25
Select e1.EmployeeID em1, e2.EmployeeID em2
From dbo.Employees E1 JOIN dbo.Employees e2 on e1.title = e2.Title and e1.EmployeeID>e2.EmployeeID

--26
Select e2.EmployeeID, e2.FirstName, e2.LastName
From dbo.Employees e1 join dbo.Employees e2 on e2.EmployeeID = e1.ReportsTo
Group by e2.EmployeeID, e2.FirstName, e2.LastName
Having Count(e1.EmployeeID)>2

--27
Select City, CompanyName as 'Name', ContactName, 'Customer' as Type
From dbo.Customers
UNION ALL
Select City, CompanyName as 'Name', ContactName, 'Supplier' as Type
From dbo.Suppliers
