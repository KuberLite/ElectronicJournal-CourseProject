create proc ShowAllProfessionByFaculty
@faculty nvarchar(50)
as
select IdProfession[ID �������������], ProfessionName[��������], Qualification[������������] from Profession
where Faculty = @faculty