create proc SelectAllTeacherByFaculty
@faculty nvarchar(50)
as
select IdPerson[ID], [Name][ФИО], Pulpit[Кафедра], Gender[Пол], Birthday[Дата рождения]
                           from Person inner join Pulpit on Person.Pulpit = Pulpit.IdPulpit
                           where Pulpit.Faculty =  @faculty