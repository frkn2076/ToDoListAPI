SELECT *
  FROM public.list
 WHERE profileId = @profileId
 LIMIT @count
OFFSET @skip
