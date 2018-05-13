create proc SortBySecondNoteForMainFormTeacher
@subject nvarchar(50),
@course int,
@numberGroup int,
@noteSecond int
as
select [Name][ФИО], [Subject][Дисциплина], NumberGroup[Номер группы], Course[Курс], NoteFirst[I Аттестация], NoteSecond[II Аттестация],
                               case
                               when(Progress.NoteFirst + Progress.NoteSecond) / 2 >= 4 then '+'
                               else '-'
							   end[Допуск]
                               from Person inner join Progress on Person.IdPerson = Progress.IdStudent
                               inner join Groups on Person.IdGroup = Groups.IdGroup
                               inner join [Subject] on Progress.[Subject] = [Subject].SubjectId
                               where SubjectId = @subject and Course = @course
                               and NumberGroup = @numberGroup
                               and NoteSecond >= @noteSecond