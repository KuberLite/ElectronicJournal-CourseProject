create proc AddTimeUpdate
@updateId varchar(50),
@personName varchar(50),
@dateUpdate datetime,
@nameTable varchar(100)
as
insert into TimeUpdate(UpdateId, PersonName, DateUpdate, NameTable)
values (@updateId, @personName, @dateUpdate, @nameTable)