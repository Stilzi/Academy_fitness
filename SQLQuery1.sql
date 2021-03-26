CREATE DATABASE Academy_fitness

USE Academy_fitness

CREATE TABLE [Trainer] (
	[Id]				INT PRIMARY KEY IDENTITY (1,1),
	[Name]				NVARCHAR(50)																		 NOT NULL
)

CREATE TABLE [Course] (
	[Id]				INT PRIMARY KEY IDENTITY (1,1),
	[Title]				NVARCHAR(50)																		 NOT NULL
)

CREATE TABLE [CourseRegistration] (
	[Id]				INT PRIMARY KEY IDENTITY (1,1),
	[TrainerId]			INT CONSTRAINT FK_Trainer_CourseRegistration FOREIGN KEY REFERENCES [Trainer] ([Id]) NOT NULL,
	[CourseId]			INT CONSTRAINT FK_Course_CourseRegistration  FOREIGN KEY REFERENCES [Course]  ([Id]) NOT NULL,
	[CreatedDate]		DATE																				 NOT NULL,
	[IsDone]			NVARCHAR(30)																		 NOT NULL,
	[TotalPoint]		INT																					 NOT NULL,
	[CertificateImage]	IMAGE																				 NULL,
	[Comment]			NVARCHAR(100)																		 NULL
)

DROP TABLE Trainer, Course, CourseRegistration