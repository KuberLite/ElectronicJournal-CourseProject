select * from Progress
select * from Person inner join [User] on Person.IdPerson = [User].Id inner join UserRoles on [User].Id = UserRoles.UserId inner join Roles on UserRoles.RoleId = Roles.IdRole where RoleId = 'S' 
select * from Groups
select * from Person
select * from [Subject]
insert into Progress([Subject], IdStudent, Note) values ('����', '51062c0f-4a62-4186-930d-62b0a6c7633a', 6)

select [Name][���], [Subject][����������], NumberGroup[����� ������], Course[����], Note[������],
case
    when Progress.Note >= 4 then '+'
    else '-'
end [�����]
from Person inner join Progress on Person.IdPerson = Progress.IdStudent 
inner join Groups on Person.IdGroup = Groups.IdGroup 
inner join [Subject] on Progress.[Subject] = [Subject].SubjectId where SubjectName = '������ �������������� � ����������������' and Course = 1 and NumberGroup = 1

update Progress set Note = 6 where IdStudent = '51062c0f-4a62-4186-930d-62b0a6c7633a'

select SubjectName
	from Person inner join Progress on Person.IdPerson = Progress.IdStudent 
	            inner join [Subject] on Progress.[Subject] = [Subject].SubjectId where Person.IdPerson = '51062c0f-4a62-4186-930d-62b0a6c7633a'
go
select IdPerson from Person inner join [User] on Person.IdPerson = [User].Id where Username = 'qwerty'
select Pulpit from Person where IdPerson = 'd997a46e-bf2b-46e4-96ba-0bf83f1234d6'

select SubjectName from Person inner join Progress on Person.IdPerson = Progress.IdStudent inner join [Subject] on Progress.[Subject] = [Subject].SubjectId where Person.IdPerson = '51062c0f-4a62-4186-930d-62b0a6c7633a'
select IdPerson from Person inner join [User] on Person.IdPerson = [User].Id where Username = 'log'		

select [Name], Gender, NumberGroup, ProfessionName, Course, Birthday, Photo
from Person inner join Groups on Person.IdGroup = Groups.IdGroup 
            inner join Profession on Groups.Profession = Profession.IdProfession
			where Person.IdPerson = '51062c0f-4a62-4186-930d-62b0a6c7633a'
go

select SubjectName[����������], 
       NoteFirst[I ����������], 
	   NoteSecond[II ����������],
	   round((Progress.NoteFirst + Progress.NoteSecond)/2, 2)[�������],
       case 
           when (Progress.NoteFirst + Progress.NoteSecond)/2 >= 5 then '+' 
           else '�.�.' 
       end[�������] 
from Person inner join Progress on Person.IdPerson = Progress.IdStudent 
inner join[Subject] on Progress.[Subject] = [Subject].SubjectId 
where Person.IdPerson = '51062c0f-4a62-4186-930d-62b0a6c7633a'

update Progress set NoteFirst = 2, NoteSecond = 3 where IdStudent = '51062c0f-4a62-4186-930d-62b0a6c7633a' and [Subject] = '���'
select * from Progress

select IdPerson[ID], [Name][���], NumberGroup[������], Gender[���], Birthday[���� ��������]
                           from Person inner join Groups on Person.IdGroup = Groups.IdGroup
						   inner join Faculty on Groups.Faculty = Faculty.IdFaculty
						   where Faculty.IdFaculty = '��'

go

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