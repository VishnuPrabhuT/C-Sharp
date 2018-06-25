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
where studentName = 'Morton Oshaughnessy'

select studentName, majorName, courseName, courseGrade, courseSemester, courseYear from tblStudent
full join tblCourseGrade on tblStudent.studentid = tblCourseGrade.studentID
join tblMajors on tblStudent.major = tblMajors.majorID
left join tblCourses on tblCourses.courseID = tblCourseGrade.courseID
where studentName = 'Morton Oshaughnessy';

DECLARE @years AS NVARCHAR(MAX), @semester AS NVARCHAR(MAX),
    @query  AS NVARCHAR(MAX);

SET @years = STUFF((SELECT distinct ',' + QUOTENAME(c.courseYear) 
            FROM tblCourses c
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')


set @query = 'SELECT courseID, courseName, ' + CONCAT(@semester, @years) + ' from 
            (
                select *
                from tblCourses
           ) x
            pivot 
            (
                max(courseSemester)
                for courseYear in (' + @cols + ')
            ) p '

execute(@query)

select * from @cols;

/*group by studentName, majorName, courseName, courseGrade, courseYear, courseSemester*/


create table test (days int, cost int);
insert into test values(0,13);
insert into test values(1,45);
insert into test values(2,57);
insert into test values(3,67);

select days,cost from test;


SELECT 'AverageCost' AS Cost_Sorted_By_Production_Days,   
[0], [1], [2], [3], [4]  
FROM  
(SELECT days, cost   
    FROM test) AS SourceTable  
PIVOT  
(  
avg(cost)
FOR days IN ([0], [1], [2], [3], [4])  
) AS PivotTable;  












