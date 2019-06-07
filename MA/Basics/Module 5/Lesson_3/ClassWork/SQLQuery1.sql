--SELECT course_id,course_name,begin_date AS [First Day] FROM dbo.courses
--SELECT * FROM courses;
--SELECT DISTINCT "TYPE" FROM courses;
--SELECT course_name, [type], quantity FROM courses ORDER BY [type] ASC, quantity DESC;

--SELECT course_name, "type", marks, quantity FROM courses ORDER BY 
--CASE WHEN type ='computer'
--		THEN quantity 
--		ELSE marks 
--END;

--SELECT course_name, "type" FROM courses WHERE quantity IN (10,20,30); 

--SELECT course_name, "type" FROM courses WHERE type = 
--(SELECT course_name FROM courses WHERE type= 'history'); 

--SELECT min(quantity) AS [Quantity min], max(quantity) AS [Quantity max] FROM courses; 

--SELECT
--	COUNT(course_id) AS "count(course_id)",
--	COUNT(marks) AS "count(marks)",
--	COUNT(*) AS "count(*)"
--FROM courses WHERE marks IS NOT NULL;


--SELECT "type",
--	SUM(marks) AS "SUM(marks)",
--	COUNT(contract) AS "COUNT(contract)",
--	COUNT(*) AS "count(*)",
--	sum(size)/COUNT(quantity) as "sum/COUNT(quantity)",
--	sum(size)/COUNT(*) as "sum/COUNT(*)",
--	avg(quantity) as "avg(quantity)"
--FROM courses group by [type];
--FROM courses;

--SELECT "type",
--	COUNT(marks) AS "COUNT(marks)",
--	avg(marks * contract) as "avg marks contract"
--FROM courses group by [type] HAVING avg(marks * contract) > 10;

--SELECT lc_id, lc_fname, lc_fname
--FROM lecturers
--WHERE lc_id IN
--	(SELECT lc_id FROM course_lecturers);

--INSERT INTO email (em_Id, em_value, lc_id) VALUES (5,'test@qmail.com','L_1');

DELETE FROM courses WHERE begin_date <= '2013-10-01'