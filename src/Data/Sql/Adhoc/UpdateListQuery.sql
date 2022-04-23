UPDATE public.list
   SET title = @title
	 , description = @description
     , date = @date
 WHERE id = @id
