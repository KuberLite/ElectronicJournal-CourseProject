create proc GetPulpitForPulpitComboBox
@faculty nvarchar(50)
as
select IdPulpit from Faculty inner join Pulpit
                           on Faculty.IdFaculty = Pulpit.Faculty 
                           where Faculty.IdFaculty = @faculty