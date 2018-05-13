create proc LoginProc
@username varchar(100),
@password varchar(100)
as

select RoleName from Roles
inner join UserRoles on Roles.IdRole = UserRoles.RoleId 
inner join [User] on UserRoles.UserId = [User].Id 
where Username = @username and PasswordHash = @password