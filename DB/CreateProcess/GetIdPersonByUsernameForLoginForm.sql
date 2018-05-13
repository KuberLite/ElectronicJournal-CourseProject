create proc GetIdPersonByUsernameForLoginForm
@username varchar(100)
as
select IdPerson from Person inner join [User] on Person.IdPerson = [User].Id where Username = @username