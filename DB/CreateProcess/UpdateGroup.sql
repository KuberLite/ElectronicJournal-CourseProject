create proc UpdateGroup
@subjectName nvarchar(100),
@pulpit nvarchar(50),
@subjectId nvarchar(50)
as
update [Subject] set SubjectName = @subjectName, Pulpit = @pulpit where SubjectId = @subjectId