create proc ShowAllUserByGender
@gender nchar(1),
@role varchar(10)
as
select IdPerson[ID], [Name][ФИО], Gender[Пол], Pulpit[Кафедра], IdGroup[ID группы], Birthday[Дата рождения], Photo[Фото], Email[Почта] 
from Person where Person.Gender = @gender