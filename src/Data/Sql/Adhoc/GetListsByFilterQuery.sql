SELECT *
  FROM public.list
 WHERE profileId = @profileId
   AND ( CASE 
	     	WHEN @datemin is NULL THEN true 
	     	ELSE date > @datemin 
	     END
	   )
   AND ( CASE 
	     	WHEN @datemax is NULL THEN true 
	     	ELSE date < @datemax 
	     END
	   )
   AND ( CASE 
	     	WHEN @title is NULL THEN true 
	     	ELSE title = @title 
	     END
	   )
 LIMIT @count
OFFSET @skip