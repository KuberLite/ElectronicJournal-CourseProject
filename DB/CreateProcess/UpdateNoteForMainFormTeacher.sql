create proc UpdateNoteForMainFormTeacher
@noteFirst int,
@noteSecond int,
@subject nvarchar(50),
@idPerson varchar(50)
as
update Progress set NoteFirst = @noteFirst, NoteSecond = @noteSecond where IdStudent = @idPerson and [Subject] = @subject