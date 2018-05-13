create proc LoadNoteForMainFormStudent
@idPerson varchar(50)
as
select SubjectName[����������], NoteFirst[I ����������], NoteSecond[II ����������], round((Progress.NoteFirst + Progress.NoteSecond) / 2, 2)[�������], 
                           case
                           when(Progress.NoteFirst + Progress.NoteSecond) / 2 >= 4 then '+'
                           else '�.�.'
                           end[�������]
                           from Person inner join Progress on Person.IdPerson = Progress.IdStudent
                           inner join[Subject] on Progress.[Subject] = [Subject].SubjectId where Person.IdPerson = @idPerson