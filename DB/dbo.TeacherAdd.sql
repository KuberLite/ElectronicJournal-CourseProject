create proc TeacherAdd
    @PersonId varchar(50),
	@Name nvarchar(100),
	@Gender nchar(1),
    @Pulpit nvarchar(50),
    @Birthday date,
    @Username varchar(100),
    @PasswordHash varchar(100)
as
	insert into Person (IdPerson, [Name], Gender, Pulpit, Birthday)
                values (@PersonId, @Name, @Gender, @Pulpit, @Birthday)
    insert into [User] (Id, [Username], PasswordHash)
                values (@PersonId, @Username, @PasswordHash)
    insert into UserRoles (UserId, RoleId)
                values (@PersonId, 'T')