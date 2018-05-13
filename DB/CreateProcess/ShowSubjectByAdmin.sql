create proc ShowSubjectByAdmin
@faculty nvarchar(50),
@pulpit nvarchar(50)
as
select * from [Subject] inner join Pulpit on [Subject].Pulpit = Pulpit.IdPulpit
                        inner join Faculty on Pulpit.Faculty = Faculty.IdFaculty
						where Pulpit.IdPulpit = @pulpit and Pulpit.Faculty = @faculty 