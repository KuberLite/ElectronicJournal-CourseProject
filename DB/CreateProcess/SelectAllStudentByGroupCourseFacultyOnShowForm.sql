create proc SelectAllSudentByGroupCourseFacultyOnShowForm
@faculty nvarchar(50),
@course int,
@numberGroup int
as
select IdPerson[ID], [Name] [���], NumberGroup[������], Gender[���], Birthday[���� ��������], Email[�����]
                               from Person inner join Groups on Person.IdGroup = Groups.IdGroup
                               inner join Faculty on Groups.Faculty = Faculty.IdFaculty
                               where Faculty.IdFaculty = @faculty
                               and Groups.Course = @course and Groups.NumberGroup = @numberGroup