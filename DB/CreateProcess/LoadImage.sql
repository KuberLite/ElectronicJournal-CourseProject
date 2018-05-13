create proc LoadImage
@idPerson varchar(50),
@img image
as
update Person set Photo = @img where IdPerson = @idPerson