UPDATE public.task
   SET title = @title
	 , description = @description
     , deadline = @deadLine
	 , isdone = @isDone
	 , listid = @listId
 WHERE id = @id
