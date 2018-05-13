create proc LoadUserInfoForUserFormStudent
@idPerson varchar(50)
as
select [Name], Gender, NumberGroup, ProfessionName, Course, Birthday, Photo 
                           from Person inner join Groups on Person.IdGroup = Groups.IdGroup 
                           inner join Profession on Groups.Profession = Profession.IdProfession 
                           where Person.IdPerson = @idPerson