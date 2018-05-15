create proc SelectAllEmail
as
select Email from Person where Email like '%@%'