    SELECT public.profile.username
         , count(public.task.id)
         , MAX(public.profile.timezone) as timezone
      FROM public.profile
INNER JOIN public.list ON public.profile.id = public.list.profileid
INNER JOIN public.task ON public.list.id = public.task.listid
     WHERE public.task.isdone = true
	   AND DATE(public.task.deadline) = CURRENT_DATE
  GROUP BY public.profile.username