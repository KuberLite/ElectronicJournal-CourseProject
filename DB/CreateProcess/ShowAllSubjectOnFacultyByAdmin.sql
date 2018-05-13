create proc ShowAllSubjectOnFacultyByAdmin
@faculty nvarchar(50)
as
select SubjectId[ID Предмета], SubjectName[Название], Pulpit[Кафедра] from [Subject] inner join Pulpit on [Subject].Pulpit = Pulpit.IdPulpit
                                                     inner join Faculty on Pulpit.Faculty = Faculty.IdFaculty 
						                             where IdFaculty = @faculty