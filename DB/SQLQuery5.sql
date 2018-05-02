select IdGroup from Groups inner join Faculty 
on Groups.Faculty = Faculty.IdFaculty where Faculty.IdFaculty = 'ИТ'

select Faculty from Groups inner join Faculty 
on Groups.Faculty = Faculty.IdFaculty where Groups.IdGroup = 211

select * from [Subject]
select * from Groups
select * from Person order by [Name]
select * from [User]

select [Name][ФИО], [Subject][Дисциплина], NumberGroup[Номер группы], Course[Курс], NoteFirst[I Аттестация], NoteSecond[II Аттестация],
case 
when(Progress.NoteFirst + Progress.NoteSecond) / 2 >= 4 then '+'
else 'н.а.' 
end[Принято]
from Person 
inner join Pulpit on P
where Pulpit.Faculty = 'ИТ'