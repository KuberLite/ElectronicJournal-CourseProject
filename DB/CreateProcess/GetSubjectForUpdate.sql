create proc GetSubjectForUpdate
@faculty nvarchar(50)
as
select SubjectId[ID ��������], Pulpit[�������], SubjectName[�������� ��������] from [Subject] inner join Pulpit
                           on [Subject].Pulpit = Pulpit.IdPulpit inner join Faculty
                           on Pulpit.Faculty = Faculty.IdFaculty where Faculty.IdFaculty = @faculty