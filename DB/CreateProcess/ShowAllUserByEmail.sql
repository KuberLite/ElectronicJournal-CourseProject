create proc ShowAllUserByEmail
@email varchar(100)
as
select IdPerson[ID], [Name][���], Gender[���], Pulpit[�������], IdGroup[ID ������], Birthday[���� ��������], Photo[����], Email[�����] 
from Person where Person.Email like '%' + @email + '%'
