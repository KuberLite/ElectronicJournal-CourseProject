create table TeacherInfo
(  
	Teacher      char(10) constraint TEACHER_PK primary key,
    FullNameTeacher  nvarchar(100), 
    Gender      nchar(1) CHECK (Gender in ('м', 'ж')),
    Pulpit      nvarchar(10) constraint Teacher_Pulpit_FK foreign key references PULPIT(Pulpit) 
)