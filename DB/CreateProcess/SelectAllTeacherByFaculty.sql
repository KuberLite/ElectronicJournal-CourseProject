create proc SelectAllTeacherByFaculty
@faculty nvarchar(50)
as
select IdPerson[ID], [Name][���], Pulpit[�������], Gender[���], Birthday[���� ��������]
                           from Person inner join Pulpit on Person.Pulpit = Pulpit.IdPulpit
                           where Pulpit.Faculty =  @faculty