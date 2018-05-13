create proc ShowAllUserBySecondName
@name nvarchar(100)
as
select * from Person where Person.[Name] like '%' + @name + '%'