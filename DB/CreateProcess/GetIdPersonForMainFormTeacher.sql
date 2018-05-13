create proc GetIdPersonForMainFormTeacher
@namePerson nvarchar(100)
as
select IdPerson from Person where [Name] = @namePerson