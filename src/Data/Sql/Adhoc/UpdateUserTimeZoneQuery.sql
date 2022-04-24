UPDATE public.profile
   SET timezone = @timeZone
 WHERE id = @profileId
