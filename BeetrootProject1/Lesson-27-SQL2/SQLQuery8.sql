select * from customers c 
join bookmovement bm
on c.customerid = bm.customerid
join books b 
on b.bookid = bm.bookid

select * from books b
join BookCategory bc
on b.CategoryID = bc.CategoryId
where CategoryDescription like '%fic%'

UPDATE bookmovement
SET isbookreturned = 0
WHERE bookreturndate >CURRENT_TIMESTAMP