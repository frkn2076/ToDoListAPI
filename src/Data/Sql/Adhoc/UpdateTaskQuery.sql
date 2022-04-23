UPDATE public.task
   SET title = @title
	 , description = @description
     , dateline = @dateLine
	 , isdone = @isDone
	 , listid = @listId
 WHERE id = @id
