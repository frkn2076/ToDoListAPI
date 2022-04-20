INSERT INTO public.profile
	      ( userName
		  , password )
	 VALUES 
	      ( @userName
		  , @password )
  RETURNING *
