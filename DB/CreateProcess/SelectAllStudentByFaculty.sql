create proc SelectAllStudentByFaculty
@faculty nvarchar(50)
as
select IdPerson[ID], [Name] [ФИО], NumberGroup[Группа], Gender[Пол], Birthday[Дата рождения]
                               from Person inner join Groups on Person.IdGroup = Groups.IdGroup
                               inner join Faculty on Groups.Faculty = Faculty.IdFaculty
                               where Faculty.IdFaculty = @faculty