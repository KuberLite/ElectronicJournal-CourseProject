create proc SelectAllTeacherByPulpit
@pulpit nvarchar(100)
as
select IdPerson[ID], [Name][���], Pulpit[�������], Gender[���], Birthday[���� ��������]
                           from Person inner join Pulpit on Person.Pulpit = Pulpit.IdPulpit
                           where Pulpit.PulpitName = @pulpit