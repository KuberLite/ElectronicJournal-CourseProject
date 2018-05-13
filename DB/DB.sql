CREATE DATABASE ELECTRONIC_JOURNAL

USE ELECTRONIC_JOURNAL

CREATE TABLE Roles
(
    IdRole varchar(50) primary key,
	RoleName varchar(10),
)

select * from Roles

CREATE TABLE [User]
(
    Id varchar(50) primary key,
	Username varchar(100),
	PasswordHash varchar(100)
)

CREATE TABLE UserRoles
(
    Id int identity(1,1),
	UserId varchar(50) foreign key references [User](Id),
	RoleId varchar(50) references Roles(IdRole)
)

CREATE TABLE Faculty
(
    IdFaculty nvarchar(50) primary key,
	FacultyName nvarchar(50) default 'NULL'    
)
  
select * from Faculty

CREATE TABLE Pulpit
(
    IdPulpit nvarchar(50) primary key,
	PulpitName nvarchar(100),
	Faculty nvarchar(50) foreign key references Faculty(IdFaculty)
)   

select * from Pulpit

CREATE TABLE [Subject]
(
    SubjectId nvarchar(50) primary key,
	SubjectName nvarchar(100) unique,
	Pulpit nvarchar(50) foreign key references Pulpit(IdPulpit)
)

select * from [Subject]

CREATE TABLE Profession
(
    IdProfession nvarchar(50) primary key,
	Faculty nvarchar(50) foreign key references Faculty(IdFaculty),
	ProfessionName nvarchar(100),
	Qualification nvarchar(50)
)

select * from Profession

CREATE TABLE Groups
(
    IdGroup int identity(1,1) primary key,
	NumberGroup int,
	Faculty nvarchar(50) foreign key references Faculty(IdFaculty),
	Profession nvarchar(50) foreign key references Profession(IdProfession),
	Course int check (Course between 1 and 12)
)

select * from Groups

CREATE TABLE Person
(
    IdPerson varchar(50) primary key ,
	[Name] nvarchar(100),
	Gender nchar(1) check (Gender in ('ì', 'æ')),
	Pulpit nvarchar(50) foreign key references Pulpit(IdPulpit),
	IdGroup int foreign key references Groups(IdGroup),
	Birthday date,
	Photo image,
	Email varchar(100)
)

CREATE TABLE Progress
(
    [Subject] nvarchar(50) foreign key references [Subject](SubjectId),
	IdStudent varchar(50) foreign key references Person(IdPerson),
	NoteFirst int check (NoteFirst between 0 and 10) default 0,
	NoteSecond int check (NoteSecond between 0 and 10) default 0
)









