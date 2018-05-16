create proc ShowAllProfessionByFaculty
@faculty nvarchar(50)
as
select IdProfession[ID специальности], ProfessionName[Название], Qualification[Квалификация] from Profession
where Faculty = @faculty