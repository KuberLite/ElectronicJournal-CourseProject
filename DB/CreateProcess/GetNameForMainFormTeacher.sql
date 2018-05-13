create proc GetNameForMainFormTeacher
@idPerson varchar(50)
as
select [Name] from Person where IdPerson = @idPerson