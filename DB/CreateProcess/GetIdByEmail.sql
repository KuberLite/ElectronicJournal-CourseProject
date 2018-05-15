create proc GetIdByEmail
@email varchar(100)
as
select IdPerson from Person where Email = @email