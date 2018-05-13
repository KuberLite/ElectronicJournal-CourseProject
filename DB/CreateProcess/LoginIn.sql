create proc LoginIn
@login varchar(100),
@pass varchar(100)
as
select RoleName from Roles
inner join UserRoles on Roles.IdRole = UserRoles.RoleId
inner join [User] on UserRoles.UserId = [User].Id where Username = @login and PasswordHash = @pass