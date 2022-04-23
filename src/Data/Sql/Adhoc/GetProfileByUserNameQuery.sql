SELECT id
     , username
     , password
  FROM public.profile
 WHERE username = @userName
