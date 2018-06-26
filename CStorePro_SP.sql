--select * from tblCourseGrade;
--select * from tblCourses;
--select * from tblMajors;
--select * from tblStudent where studentName = 'Quinn Jauregui';

CREATE PROCEDURE rptGetStudentReportCardByMajor @InMajorID int
AS
	select studentName, majorName, courseName, tblCourseGrade.courseID
		[Fall 2014], [Spring 2014],
		[Fall 2015], [Spring 2015],
		[Fall 2016], [Spring 2016],
		[Fall 2017], [Spring 2017],
		[Fall 2018], [Spring 2018]
		from tblStudent
			full join tblCourseGrade on tblStudent.studentid = tblCourseGrade.studentID
			join tblMajors on tblStudent.major = tblMajors.majorID
			join tblCourses on tblCourses.courseID = tblCourseGrade.courseID
			join (select courseID,
					max(case when cols = 'Fall 2014' then COALESCE(NULLIF(CAST(courseGrade AS VARCHAR(10)) ,'0'), '') else '' end) 'Fall 2014',
					max(case when cols = 'Spring 2014' then COALESCE(NULLIF(CAST(courseGrade AS VARCHAR(10)) ,'0'), '') else '' end) 'Spring 2014',
					max(case when cols = 'Fall 2015' then COALESCE(NULLIF(CAST(courseGrade AS VARCHAR(10)) ,'0'), '') else '' end) 'Fall 2015',
					max(case when cols = 'Spring 2015' then COALESCE(NULLIF(CAST(courseGrade AS VARCHAR(10)) ,'0'), '') else '' end) 'Spring 2015',
					max(case when cols = 'Fall 2016' then COALESCE(NULLIF(CAST(courseGrade AS VARCHAR(10)) ,'0'), '') else '' end) 'Fall 2016',
					max(case when cols = 'Spring 2016' then COALESCE(NULLIF(CAST(courseGrade AS VARCHAR(10)) ,'0'), '') else '' end) 'Spring 2016',
					max(case when cols = 'Fall 2017' then COALESCE(NULLIF(CAST(courseGrade AS VARCHAR(10)) ,'0'), '') else '' end) 'Fall 2017',
					max(case when cols = 'Spring 2017' then COALESCE(NULLIF(CAST(courseGrade AS VARCHAR(10)) ,'0'), '') else '' end) 'Spring 2017',
					max(case when cols = 'Fall 2018' then COALESCE(NULLIF(CAST(courseGrade AS VARCHAR(10)) ,'0'), '') else '' end) 'Fall 2018',
					max(case when cols = 'Spring 2018' then COALESCE(NULLIF(CAST(courseGrade AS VARCHAR(10)) ,'0'), '') else '' end) 'Spring 2018'
					from (select c1.courseID, courseGrade, CONCAT(courseSemester, ' ',CONVERT(nvarchar, courseYear)) as cols
						from (select distinct courseSemester, tblCourseGrade.courseID, courseGrade from tblCourses
								join tblCourseGrade on tblCourseGrade.courseID = tblCourses.courseID
						) c1
					cross join (select distinct courseYear from tblCourses) c2 ) base
					group by courseID
		) main on tblCourseGrade.courseID = main.courseID
		where major = @InMajorID







