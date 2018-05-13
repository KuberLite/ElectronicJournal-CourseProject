create proc SelectAllSudentByFacultyCourse
@faculty nvarchar(50),
@course int 
as
select IdPerson[ID], [Name] [ФИО], NumberGroup[Группа], Gender[Пол], Birthday[Дата рождения]
                               from Person inner join Groups on Person.IdGroup = Groups.IdGroup
                               inner join Faculty on Groups.Faculty = Faculty.IdFaculty
                               where Faculty.IdFaculty = @faculty and Groups.Course = @course