create proc ShowAllUser
as
select IdPerson[ID], [Name][ФИО], Gender[Пол], Pulpit[Кафедра], IdGroup[ID группы], Birthday[Дата рождения], Photo[Фото], Email[Почта] from
Person