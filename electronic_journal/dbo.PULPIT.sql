CREATE TABLE [dbo].[PULPIT] (
    [PulpitId]   INT            IDENTITY (1, 1) NOT NULL,
    [Pulpit]     NVARCHAR (10)  NOT NULL,
    [PulpitName] NVARCHAR (100) NULL,
    [Faculty]    NVARCHAR (5)   NULL, 
    CONSTRAINT [PK_PULPIT] PRIMARY KEY ([Pulpit])
);

