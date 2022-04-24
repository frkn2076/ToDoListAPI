UPDATE public.task
   SET isdone = @isDone
 WHERE id = @id
