create proc SelectAllTeacherByFacultyOnShowForm
@faculty nvarchar(50)
as
select IdPerson[ID], [Name][���], Pulpit[�������], Gender[���], Birthday[���� ��������], Email[�����]
                           from Person inner join Pulpit on Person.Pulpit = Pulpit.IdPulpit
                           where Pulpit.Faculty =  @faculty