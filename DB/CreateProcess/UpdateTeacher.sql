create proc UpdateTeacher
@name nvarchar(100),
@pulpit nvarchar(50),
@gender nchar(1),
@birthday date,
@idPerson varchar(50)
as
update Person set [Name] = @name,
                  Pulpit = @pulpit,
                  Gender = @gender,
                  Birthday = @birthday
                  where IdPerson = @idPerson