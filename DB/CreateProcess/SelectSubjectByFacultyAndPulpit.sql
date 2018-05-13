create proc SelectSubjectByFacultyAndPulpit
@faculty nvarchar(50),
@pulpit nvarchar(100)
as
select SubjectId[ID ��������], Pulpit[�������], SubjectName[�������� ��������] from [Subject] inner join Pulpit
                               on [Subject].Pulpit = Pulpit.IdPulpit inner join Faculty
                               on Pulpit.Faculty = Faculty.IdFaculty where Faculty.IdFaculty = @faculty and Pulpit.PulpitName = @pulpit