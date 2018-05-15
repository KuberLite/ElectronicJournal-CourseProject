create proc AddRequest
@id varchar(50),
@email varchar(100),
@time datetime
as
insert into Requests(Id, Email, TimeRequest) values (@id, @email, @time)