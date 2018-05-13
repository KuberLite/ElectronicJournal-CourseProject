create proc GetGroupForGroupComboBox
@faculty nvarchar(50),
@course int
as
select distinct numberGroup from Groups inner join Faculty 
                           on Groups.Faculty = Faculty.IdFaculty
                           where Faculty.IdFaculty = @faculty
						   and Groups.Course = @course