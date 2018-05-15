create proc UpdatePassword
@passHash varchar(100),
@id varchar(50)
as
update [User] set PasswordHash = @passHash where Id = @id