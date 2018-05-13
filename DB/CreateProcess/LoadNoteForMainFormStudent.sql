create proc LoadNoteForMainFormStudent
@idPerson varchar(50)
as
select SubjectName[Дисциплина], NoteFirst[I Аттестация], NoteSecond[II Аттестация], round((Progress.NoteFirst + Progress.NoteSecond) / 2, 2)[Среднее], 
                           case
                           when(Progress.NoteFirst + Progress.NoteSecond) / 2 >= 4 then '+'
                           else 'н.а.'
                           end[Принято]
                           from Person inner join Progress on Person.IdPerson = Progress.IdStudent
                           inner join[Subject] on Progress.[Subject] = [Subject].SubjectId where Person.IdPerson = @idPerson