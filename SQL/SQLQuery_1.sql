--1
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product

--2
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE ListPrice<>0

--3
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color is Null

--4
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color is Not Null

--5
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color is Not Null AND ListPrice>0

--6
SELECT Name, Color
FROM Production.Product
WHERE Color is Not Null

--7
SELECT Name, Color
FROM Production.Product
WHERE Name in ('LL Crankarm','ML Crankarm','HL Crankarm','Chainring Bolts','Chainring Nut','Chainring')

--8
SELECT ProductID, Name
FROM Production.Product
WHERE ProductID BETWEEN 400 and 500

--9
SELECT p.ProductID, p.Name, p.Color
FROM Production.Product p
WHERE p.Color in ('Black','Blue')

--10
SElECT *
FROM Production.Product
Where Name like 'S%'

--11
SELECT Name, ListPrice
FROM Production.Product
Where Name like 'S%'
ORDER BY name

--12
SELECT Name, ListPrice
FROM Production.Product
Where Name like 'S%' OR Name like 'A%'
ORDER BY name
--13
SELECT Name, ListPrice
FROM Production.Product
Where Name like 'SPO%' and Name not like 'SPOK%'
ORDER BY name

--14
SELECT DISTINCT Color
FROM Production.Product
Order by Color desc

--15
SELECT Distinct ProductSubcategoryID, Color
FROM Production.Product
Where ProductSubcategoryID is not NULL and Color is not Null
ORDER BY ProductSubcategoryID, Color
