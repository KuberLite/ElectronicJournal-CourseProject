create proc ShowPulpitByAdmin
@faculty nvarchar(50)
as
select IdPulpit[ID �������], PulpitName[PulpitName], Faculty[���������] from Pulpit where Pulpit.Faculty = @faculty