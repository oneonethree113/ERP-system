/****** Object:  StoredProcedure [dbo].[sp_update_TOORDDTL_3]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_TOORDDTL_3]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_TOORDDTL_3]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











CREATE     PROCEDURE [dbo].[sp_update_TOORDDTL_3] 


@tod_cocde		nvarchar(6),
@tod_toordno		nvarchar(20),
@tod_toordseq 		int,
@tod_projqty		int,
@user			nvarchar(30)
AS



UPDATE	TOORDDTL
SET		tod_projqty=@tod_projqty,
		tod_updusr =@user,
		tod_upddat = getdate()
		where
		tod_cocde = @tod_cocde and
		tod_toordno= @tod_toordno	 and 
		 tod_toordseq  = @tod_toordseq  and 
 		tod_latest = 'Y'
		and tod_toordno in 
			(select toh_toordno from toordhdr
				where toh_ordsts <> 'REL' )












GO
GRANT EXECUTE ON [dbo].[sp_update_TOORDDTL_3] TO [ERPUSER] AS [dbo]
GO
