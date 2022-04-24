SELECT *
  FROM public.task
 WHERE listid = @listId
   AND isdone = @isDone
   AND ( CASE 
	     	WHEN @deadlineMin is NULL THEN true 
	     	ELSE deadline > @deadlineMin 
	     END
	   )
   AND ( CASE 
	     	WHEN @deadlineMax is NULL THEN true 
	     	ELSE deadline < @deadlineMax 
	     END
	   )