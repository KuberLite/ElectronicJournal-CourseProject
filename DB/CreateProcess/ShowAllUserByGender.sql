create proc ShowAllUserByGender
@gender nchar(1),
@role varchar(10)
as
select IdPerson[ID], [Name][���], Gender[���], Pulpit[�������], IdGroup[ID ������], Birthday[���� ��������], Photo[����], Email[�����] 
from Person where Person.Gender = @gender