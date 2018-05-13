create proc ShowPulpitByAdmin
@faculty nvarchar(50)
as
select IdPulpit[ID Кафедры], PulpitName[PulpitName], Faculty[Факультет] from Pulpit where Pulpit.Faculty = @faculty