create proc ShowUserLoginData
as
select [User].Id[ID], [Name][���], Username[�����], PasswordHash[���������], [RoleName][����]
from [Roles] inner join UserRoles on Roles.IdRole = UserRoles.RoleId
             inner join [User] on UserRoles.UserId = [User].Id 
			 inner join Person on [User].Id = Person.IdPerson
                    