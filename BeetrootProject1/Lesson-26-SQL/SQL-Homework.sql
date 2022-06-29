--select all males
--select all persons with age about 18
--select all persons without address
--update age of all persons, add 1 year
--delete all rows without address
--count number of rows in table
--group persons by age and show how many persons with same age

select * from Persons
where Gender = 'M'

select * from Persons
where age > 18

select * from Persons
where Address is null

delete from Persons where address is null

select count (*) rows from Persons

select Age , count (*) sameAge from Persons
group by Age

