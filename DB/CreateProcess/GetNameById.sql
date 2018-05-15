create proc GetNameById
@id varchar(50)
as
select [Name] from Person where IdPerson = @id