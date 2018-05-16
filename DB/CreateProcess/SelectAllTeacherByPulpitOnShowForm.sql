create proc SelectAllTeacherByPulpitOnShowForm
@pulpit nvarchar(100)
as
select IdPerson[ID], [Name][ФИО], Pulpit[Кафедра], Gender[Пол], Birthday[Дата рождения], Email[Почта]
                           from Person where Pulpit = @pulpit