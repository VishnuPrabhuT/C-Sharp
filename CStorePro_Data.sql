GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCourseGrade](
	[studentID] [int] NOT NULL,
	[courseID] [int] NOT NULL,
	[courseGrade] [int] NOT NULL,
 CONSTRAINT [PK_tblCourseGrade] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC,
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCourses](
	[courseID] [int] IDENTITY(1,1) NOT NULL,
	[courseName] [nvarchar](250) NOT NULL,
	[courseSemester] [nvarchar](250) NULL,
	[courseYear] [int] NOT NULL,
 CONSTRAINT [PK_tblCourses] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMajors](
	[majorID] [int] IDENTITY(1,1) NOT NULL,
	[majorName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tblMajors] PRIMARY KEY CLUSTERED 
(
	[majorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudent](
	[studentid] [int] IDENTITY(1,1) NOT NULL,
	[studentName] [nvarchar](250) NOT NULL,
	[gender] [nvarchar](1) NOT NULL,
	[major] [int] NOT NULL,
 CONSTRAINT [PK_tblStudent] PRIMARY KEY CLUSTERED 
(
	[studentid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblCourseGrade]  WITH CHECK ADD  CONSTRAINT [FK_tblCourseGrade_tblCourses] FOREIGN KEY([courseID])
REFERENCES [dbo].[tblCourses] ([courseID])
GO
ALTER TABLE [dbo].[tblCourseGrade] CHECK CONSTRAINT [FK_tblCourseGrade_tblCourses]
GO
ALTER TABLE [dbo].[tblCourseGrade]  WITH CHECK ADD  CONSTRAINT [FK_tblCourseGrade_tblStudent] FOREIGN KEY([studentID])
REFERENCES [dbo].[tblStudent] ([studentid])
GO
ALTER TABLE [dbo].[tblCourseGrade] CHECK CONSTRAINT [FK_tblCourseGrade_tblStudent]
GO
ALTER TABLE [dbo].[tblStudent]  WITH CHECK ADD  CONSTRAINT [FK_tblStudent_tblMajors] FOREIGN KEY([major])
REFERENCES [dbo].[tblMajors] ([majorID])
GO
ALTER TABLE [dbo].[tblStudent] CHECK CONSTRAINT [FK_tblStudent_tblMajors]
GO

GO
CREATE PROCEDURE dbo.rptGetStudentReportCardByMajor
	@InMajorID	INT
AS
BEGIN
	SELECT  @InMajorID
	--NOTE to Candidate, Replace the above SELECT statement with your Query
END
GO

SET IDENTITY_INSERT dbo.tblMajors ON
INSERT INTO tblMajors(majorID, majorName)
VALUES
( 1, N'Computer Science' ), 
( 2, N'Math' ), 
( 3, N'Psychology' ), 
( 4, N'Philsophy' ), 
( 5, N'Finance' )
SET IDENTITY_INSERT dbo.tblMajors OFF
GO
SET IDENTITY_INSERT dbo.tblCourses ON
INSERT INTO dbo.tblCourses (courseID, courseName, courseSemester, courseYear)
VALUES
( 1, N'Intro to Math', N'Fall', 2014 ), 
( 2, N'Intro to Math', N'Spring', 2014 ), 
( 3, N'Intro to Math', N'Fall', 2015 ), 
( 4, N'Intro to Math', N'Spring', 2015 ), 
( 5, N'Intro to Math', N'Fall', 2016 ), 
( 6, N'Intro to Math', N'Spring', 2016 ), 
( 7, N'Intro to Math', N'Fall', 2017 ), 
( 8, N'Intro to Math', N'Spring', 2017 ), 
( 9, N'Intro to Math', N'Fall', 2018 ), 
( 10, N'Intro to Math', N'Spring', 2018 ), 
( 11, N'Computer Science 101', N'Fall', 2014 ), 
( 12, N'Computer Science 101', N'Spring', 2014 ), 
( 13, N'Computer Science 101', N'Fall', 2015 ), 
( 14, N'Computer Science 101', N'Spring', 2015 ), 
( 15, N'Computer Science 101', N'Fall', 2016 ), 
( 16, N'Computer Science 101', N'Spring', 2016 ), 
( 17, N'Computer Science 101', N'Fall', 2017 ), 
( 18, N'Computer Science 101', N'Spring', 2017 ), 
( 19, N'Computer Science 101', N'Fall', 2018 ), 
( 20, N'Computer Science 101', N'Spring', 2018 ), 
( 21, N'Psychology 101', N'Fall', 2014 ), 
( 22, N'Psychology 101', N'Spring', 2014 ), 
( 23, N'Psychology 101', N'Fall', 2015 ), 
( 24, N'Psychology 101', N'Spring', 2015 ), 
( 25, N'Psychology 101', N'Fall', 2016 ), 
( 26, N'Psychology 101', N'Spring', 2016 ), 
( 27, N'Psychology 101', N'Fall', 2017 ), 
( 28, N'Psychology 101', N'Spring', 2017 ), 
( 29, N'Psychology 101', N'Fall', 2018 ), 
( 30, N'Psychology 101', N'Spring', 2018 ), 
( 31, N'Physics 101', N'Fall', 2014 ), 
( 32, N'Physics 101', N'Spring', 2014 ), 
( 33, N'Physics 101', N'Fall', 2015 ), 
( 34, N'Physics 101', N'Spring', 2015 ), 
( 35, N'Physics 101', N'Fall', 2016 ), 
( 36, N'Physics 101', N'Spring', 2016 ), 
( 37, N'Physics 101', N'Fall', 2017 ), 
( 38, N'Physics 101', N'Spring', 2017 ), 
( 39, N'Physics 101', N'Fall', 2018 ), 
( 40, N'Physics 101', N'Spring', 2018 ), 
( 41, N'Eastern Poetry', N'Fall', 2014 ), 
( 42, N'Eastern Poetry', N'Spring', 2014 ), 
( 43, N'Eastern Poetry', N'Fall', 2015 ), 
( 44, N'Eastern Poetry', N'Spring', 2015 ), 
( 45, N'Eastern Poetry', N'Fall', 2016 ), 
( 46, N'Eastern Poetry', N'Spring', 2016 ), 
( 47, N'Eastern Poetry', N'Fall', 2017 ), 
( 48, N'Eastern Poetry', N'Spring', 2017 ), 
( 49, N'Eastern Poetry', N'Fall', 2018 ), 
( 50, N'Eastern Poetry', N'Spring', 2018 ), 
( 51, N'Economics', N'Fall', 2014 ), 
( 52, N'Economics', N'Spring', 2014 ), 
( 53, N'Economics', N'Fall', 2015 ), 
( 54, N'Economics', N'Spring', 2015 ), 
( 55, N'Economics', N'Fall', 2016 ), 
( 56, N'Economics', N'Spring', 2016 ), 
( 57, N'Economics', N'Fall', 2017 ), 
( 58, N'Economics', N'Spring', 2017 ), 
( 59, N'Economics', N'Fall', 2018 ), 
( 60, N'Economics', N'Spring', 2018 )
SET IDENTITY_INSERT dbo.tblCourses OFF

GO
SET IDENTITY_INSERT dbo.tblStudent ON
INSERT INTO dbo.tblStudent(studentid, studentName, gender, major)
VALUES
( 1, N'Quinn Jauregui', N'M', 1 ), 
( 2, N'Bill Dumbleton', N'M', 2 ), 
( 3, N'Terrence Zalenski', N'M', 3 ), 
( 4, N'Jeffery Dazey', N'M', 4 ), 
( 5, N'Darryl Honaker', N'M', 5 ), 
( 6, N'Mason Bowe', N'M', 1 ), 
( 7, N'Zachariah Caesar', N'M', 2 ), 
( 8, N'Lucius Ripple', N'M', 3 ), 
( 9, N'Brenton Ines', N'M', 4 ), 
( 10, N'Vern Reamer', N'M', 5 ), 
( 11, N'Lacy Hirst', N'M', 1 ), 
( 12, N'Jared Ferrara', N'M', 2 ), 
( 13, N'Noe Scheiber', N'M', 3 ), 
( 14, N'Jeramy Tozier', N'M', 4 ), 
( 15, N'Terence Boehm', N'M', 5 ), 
( 16, N'Israel Gust', N'M', 1 ), 
( 17, N'Hiram Sones', N'M', 2 ), 
( 18, N'Buford Herrell', N'M', 3 ), 
( 19, N'Chet Bruder', N'M', 4 ), 
( 20, N'Freddy Doman', N'M', 5 ), 
( 21, N'Porter Olivero', N'M', 1 ), 
( 22, N'Odis Cerrone', N'M', 2 ), 
( 23, N'Vincenzo Perrault', N'M', 3 ), 
( 24, N'Nolan Caffey', N'M', 4 ), 
( 25, N'Solomon Dvorak', N'M', 5 ), 
( 26, N'Elisha Torsiello', N'M', 1 ), 
( 27, N'Rodolfo Cecere', N'M', 2 ), 
( 28, N'Marlin Stalling', N'M', 3 ), 
( 29, N'Lynwood Casazza', N'M', 4 ), 
( 30, N'Tyson Mart', N'M', 5 ), 
( 31, N'John Zurita', N'M', 1 ), 
( 32, N'Denis Tinnin', N'M', 2 ), 
( 33, N'Elwood Birdsell', N'M', 3 ), 
( 34, N'Jan Rugg', N'M', 4 ), 
( 35, N'Wilber Kropp', N'M', 5 ), 
( 36, N'Whitney Du', N'M', 1 ), 
( 37, N'Morton Oshaughnessy', N'M', 2 ), 
( 38, N'Dannie Poirier', N'M', 3 ), 
( 39, N'Val Hammer', N'M', 4 ), 
( 40, N'Stuart Pedone', N'M', 5 ), 
( 41, N'Lupe Cassano', N'M', 1 ), 
( 42, N'Lynn Dieguez', N'M', 2 ), 
( 43, N'Cordell Brochu', N'M', 3 ), 
( 44, N'Bart Cordeiro', N'M', 4 ), 
( 45, N'Trenton Royals', N'M', 5 ), 
( 46, N'Alvin Mash', N'M', 1 ), 
( 47, N'Eldon Bitter', N'M', 2 ), 
( 48, N'Gerardo Kroner', N'M', 3 ), 
( 49, N'Tyrell Mally', N'M', 4 ), 
( 50, N'Jeffry Dela', N'M', 5 )
SET IDENTITY_INSERT dbo.tblStudent OFF
GO

GO
INSERT INTO dbo.tblCourseGrade ( studentID ,courseID ,courseGrade )
VALUES
( 1, 38, 91 ), 
( 1, 54, 72 ), 
( 1, 57, 73 ), 
( 2, 5, 87 ), 
( 2, 39, 81 ), 
( 2, 46, 87 ), 
( 2, 57, 78 ), 
( 3, 14, 87 ), 
( 3, 38, 82 ), 
( 3, 40, 91 ), 
( 3, 58, 83 ), 
( 4, 23, 83 ), 
( 4, 30, 95 ), 
( 4, 41, 94 ), 
( 4, 59, 88 ), 
( 5, 22, 93 ), 
( 5, 33, 83 ), 
( 5, 42, 95 ), 
( 5, 60, 73 ), 
( 6, 15, 90 ), 
( 6, 42, 83 ), 
( 6, 43, 91 ), 
( 6, 60, 78 ), 
( 7, 7, 96 ), 
( 7, 44, 78 ), 
( 7, 51, 83 ), 
( 8, 45, 69 ), 
( 9, 45, 80 ), 
( 10, 46, 90 ), 
( 11, 9, 91 ), 
( 11, 47, 83 ), 
( 11, 55, 98 ), 
( 12, 18, 91 ), 
( 12, 28, 90 ), 
( 12, 48, 91 ), 
( 13, 27, 91 ), 
( 13, 40, 97 ), 
( 13, 49, 93 ), 
( 14, 32, 89 ), 
( 14, 37, 91 ), 
( 14, 50, 97 ), 
( 15, 24, 78 ), 
( 15, 46, 96 ), 
( 15, 51, 93 ), 
( 16, 16, 75 ), 
( 16, 52, 77 ), 
( 16, 55, 96 ), 
( 17, 8, 90 ), 
( 17, 53, 69 ), 
( 18, 54, 81 ), 
( 19, 3, 93 ), 
( 19, 55, 92 ), 
( 20, 13, 93 ), 
( 20, 56, 83 ), 
( 21, 17, 90 ), 
( 21, 22, 93 ), 
( 21, 57, 70 ), 
( 22, 31, 99 ), 
( 22, 49, 67 ), 
( 22, 57, 95 ), 
( 23, 40, 99 ), 
( 23, 41, 82 ), 
( 23, 58, 97 ), 
( 24, 33, 97 ), 
( 24, 50, 99 ), 
( 24, 59, 92 ), 
( 25, 26, 85 ), 
( 25, 59, 99 ), 
( 25, 60, 79 ), 
( 26, 18, 80 ), 
( 27, 10, 93 ), 
( 28, 2, 91 ), 
( 28, 7, 95 ), 
( 29, 16, 100 ), 
( 30, 26, 100 ), 
( 31, 35, 100 ), 
( 31, 59, 77 ), 
( 32, 44, 100 ), 
( 32, 51, 93 ), 
( 33, 43, 88 ), 
( 33, 54, 91 ), 
( 34, 1, 78 ), 
( 34, 35, 92 ), 
( 35, 1, 83 ), 
( 35, 27, 99 ), 
( 36, 2, 91 ), 
( 36, 19, 73 ), 
( 36, 52, 88 ), 
( 37, 3, 93 ), 
( 37, 11, 70 ), 
( 37, 12, 69 ), 
( 38, 4, 85 ), 
( 38, 20, 70 ), 
( 38, 34, 98 ), 
( 39, 4, 83 ), 
( 39, 30, 70 ), 
( 40, 5, 88 ), 
( 40, 39, 75 ), 
( 41, 6, 90 ), 
( 41, 48, 75 ), 
( 41, 60, 91 ), 
( 42, 7, 95 ), 
( 42, 52, 91 ), 
( 42, 57, 75 ), 
( 43, 7, 92 ), 
( 43, 45, 62 ), 
( 44, 8, 97 ), 
( 44, 37, 94 ), 
( 45, 5, 61 ), 
( 45, 9, 93 ), 
( 45, 29, 65 ), 
( 46, 9, 98 ), 
( 46, 15, 61 ), 
( 46, 21, 80 ), 
( 47, 10, 92 ), 
( 47, 13, 95 ), 
( 47, 24, 67 ), 
( 48, 1, 94 ), 
( 48, 5, 88 ), 
( 48, 11, 97 ), 
( 48, 33, 67 ), 
( 49, 2, 96 ), 
( 49, 12, 93 ), 
( 49, 43, 67 ), 
( 50, 3, 98 ), 
( 50, 12, 98 ), 
( 50, 52, 67 )
GO