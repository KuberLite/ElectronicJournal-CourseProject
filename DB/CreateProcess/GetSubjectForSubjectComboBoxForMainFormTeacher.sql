create proc GetSubjectForSubjectComboBoxForMainFormTeacher
@pulpitId nvarchar(50)
as
select SubjectId from Subject inner join Pulpit on Subject.Pulpit = Pulpit.IdPulpit where Pulpit.IdPulpit = @pulpitId