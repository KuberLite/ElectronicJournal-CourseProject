create proc GetPulpitForPulpitComboBoxByAdmin
@faculty nvarchar(50)
as
select PulpitName from Faculty inner join Pulpit
                           on Faculty.IdFaculty = Pulpit.Faculty 
                           where Faculty.IdFaculty = @faculty