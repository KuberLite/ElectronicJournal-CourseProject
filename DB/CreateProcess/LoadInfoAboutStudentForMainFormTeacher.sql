create proc LoadInfoAboutStudentForMainFormTeacher
@personName nvarchar(100)
as
select [Name], Gender, NumberGroup, ProfessionName, Course, Birthday, Photo
                           from Person inner join Groups on Person.IdGroup = Groups.IdGroup
                           inner join Profession on Groups.Profession = Profession.IdProfession 
                           where Person.[Name] = @personName