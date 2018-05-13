create proc SelectGroupId
@course int,
@faculty nvarchar(50),
@group int
as
select IdGroup from Groups inner join Faculty 
                           on Groups.Faculty = Faculty.IdFaculty
                           where Faculty.IdFaculty = @faculty and Groups.Course = @course
                           and Groups.NumberGroup = @group