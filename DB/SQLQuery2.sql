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
