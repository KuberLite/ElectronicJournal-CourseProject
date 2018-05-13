create proc UpdateStudent
@name nvarchar(100),
@gender nchar(1),
@birthday date,
@idGroup int,
@idPerson varchar(50)
as
update Person set [Name] = @name, 
                  Gender = @gender, 
                  Birthday = @birthday,
                  IdGroup = @idGroup where IdPerson = @idPerson