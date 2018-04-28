create table [Subject]
(     
	[Subject]      char(10) constraint Subject_PK primary key, 
    [SubjectName]  nvarchar(100) unique,
    [Pulpit]       nvarchar(10)
)