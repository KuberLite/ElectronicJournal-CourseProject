create proc SelectAllTeacherByPulpitOnShowForm
@pulpit nvarchar(100)
as
select IdPerson[ID], [Name][���], Pulpit[�������], Gender[���], Birthday[���� ��������], Email[�����]
                           from Person where Pulpit = @pulpit