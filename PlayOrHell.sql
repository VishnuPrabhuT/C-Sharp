--select * from tblCourseGrade;
--select * from tblCourses;
--select * from tblMajors;
--select * from tblStudent;

DECLARE @courseSemester varchar(60)
select courseSemester
into v_couseSemester
from tblCourses

select * from tblStudent
join tblCourseGrade on tblStudent.studentid = tblCourseGrade.studentID
join tblMajors on tblStudent.major = tblMajors.majorID
where studentName = 'Quinn Jauregui'

select studentName, majorName, courseName, courseGrade, courseSemester, courseYear from tblStudent
full join tblCourseGrade on tblStudent.studentid = tblCourseGrade.studentID
join tblMajors on tblStudent.major = tblMajors.majorID
join tblCourses on tblCourses.courseID = tblCourseGrade.courseID
where studentName = '';

DECLARE @years AS NVARCHAR(MAX), @semester AS NVARCHAR(MAX),
    @query  AS NVARCHAR(MAX);



SET @years = STUFF((SELECT distinct ',' + QUOTENAME(course) 
            FROM (select ROW_NUMBER() over (order by courseYear asc) as courseID, CONCAT(courseSemester, ' ',CONVERT(nvarchar, courseYear)) as cols
				  from (select distinct courseSemester from tblCourses) c1 
				  cross join (select distinct courseYear from tblCourses) c2 ) c
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')


set @query = 'SELECT courseID, courseName, ' + @years + ' from 
            (
                select *
                from tblCourses
           ) x
            pivot 
            (
                max(courseSemester)
                for courseYear in (' + @years + ')
            ) p '

execute(@query)

with years as (select courseYear from tblCourses)


select * from @cols;

select distinct ROW_NUMBER() over (order by courseID asc) as c, courseID, courseName, CONCAT(courseSemester, ' ',CONVERT(nvarchar, courseYear)) as cols
			from (select distinct courseSemester, courseName from tblCourses) c1 
			cross join (select distinct courseYear, courseID from tblCourses) c2
			order by courseID
/*group by studentName, majorName, courseName, courseGrade, courseYear, courseSemester*/

select * from tblCourses
	

			

Declare @semyear nvarchar(200)

select @semyear = CONCAT(c1.courseSemester , ' ',Convert(nvarchar, c2.courseYear))
			from (select distinct courseSemester from tblCourses) c1 
			cross join (select distinct courseYear from tblCourses) c2 order by courseSemester, courseYear

select @semyear


DECLARE db_cursor CURSOR FOR SELECT course, age, color FROM tblCourses; 
DECLARE @myName VARCHAR(256);
DECLARE @myAge INT;
DECLARE @myFavoriteColor VARCHAR(40);
OPEN db_cursor;
FETCH NEXT FROM db_cursor INTO @myName, @myAge, @myFavoriteColor;
WHILE @@FETCH_STATUS = 0  
BEGIN  

       --Do stuff with scalar values

       FETCH NEXT FROM db_cursor INTO @myName, @myAge, @myFavoriteColor;
END;
CLOSE db_cursor;
DEALLOCATE db_cursor;

--New Cop!

select courseID,
  max(case when cols = 'Fall 2014' then 'X' else '' end) 'Fall 2014' ,
  max(case when cols = 'Spring 2014' then 'X' else '' end) 'Spring 2014',
  max(case when cols = 'Fall 2015' then 'X' else '' end) 'Fall 2015',
  max(case when cols = 'Spring 2015' then 'X' else '' end) 'Spring 2015',
  max(case when cols = 'Fall 2016' then 'X' else '' end) 'Fall 2016',
  max(case when cols = 'Spring 2016' then 'X' else '' end) 'Spring 2016',
  max(case when cols = 'Fall 2017' then 'X' else '' end) 'Fall 2017',
  max(case when cols = 'Spring 2017' then 'X' else '' end) 'Spring 2017',
  max(case when cols = 'Fall 2018' then 'X' else '' end) 'Fall 2018',
  max(case when cols = 'Spring 2018' then 'X' else '' end) 'Spring 2018'
from  (select courseID, CONCAT(courseSemester, ' ',CONVERT(nvarchar, courseYear)) as cols
			from (select distinct courseSemester, courseID from tblCourses) c1 
			cross join (select distinct courseYear from tblCourses) c2 ) base
group by courseID



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








