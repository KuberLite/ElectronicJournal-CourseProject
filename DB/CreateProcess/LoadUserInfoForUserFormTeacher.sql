create proc LoadUserInfoForUserFormTeacher
@idPerson varchar(50)
as
select [Name], Gender, Pulpit, Birthday, Photo from Person where IdPerson = @idPerson