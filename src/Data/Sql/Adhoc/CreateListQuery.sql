INSERT INTO public.list
	      ( title
		  , description
		  , date
		  , profileid)
	 VALUES 
	      ( @title
		  , @description
		  , @date
		  , @profileId)
  RETURNING *