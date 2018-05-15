create proc ShowAllUserByEmail
@email varchar(100)
as
select IdPerson[ID], [Name][ФИО], Gender[Пол], Pulpit[Кафедра], IdGroup[ID группы], Birthday[Дата рождения], Photo[Фото], Email[Почта] 
from Person where Person.Email like '%' + @email + '%'
