select IdGroup from Groups inner join Faculty 
on Groups.Faculty = Faculty.IdFaculty where Faculty.IdFaculty = '��'

select Faculty from Groups inner join Faculty 
on Groups.Faculty = Faculty.IdFaculty where Groups.IdGroup = 211

select * from [Subject]
select * from Groups
select * from Person order by [Name]
select * from [User]

select [Name][���], [Subject][����������], NumberGroup[����� ������], Course[����], NoteFirst[I ����������], NoteSecond[II ����������],
case 
when(Progress.NoteFirst + Progress.NoteSecond) / 2 >= 4 then '+'
else '�.�.' 
end[�������]
from Person 
inner join Pulpit on P
where Pulpit.Faculty = '��'