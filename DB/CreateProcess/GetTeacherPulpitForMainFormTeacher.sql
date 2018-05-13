create proc GetTeacherPulpitForMainFormTeacher
@idPerson varchar(50)
as
select Pulpit from Person where IdPerson = @idPerson