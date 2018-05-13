create proc AddNewPulpit
@pulpit nvarchar(50),
@pulpitName nvarchar(50),
@faculty nvarchar(50)
as
insert into Pulpit(IdPulpit, PulpitName, Faculty)
values (@pulpit, @pulpitName, @faculty)
