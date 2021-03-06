/****** Object:  StoredProcedure [dbo].[sp_update_TODTLSHP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_TODTLSHP]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_TODTLSHP]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sp_update_TODTLSHP] 


@tds_cocde		nvarchar(6),
@tds_toordno		nvarchar(20),
@tds_toordseq		int,
@tds_verno 		int,
@tds_shpseq		int,
@tds_ftyshpstr		datetime,
@tds_ftyshpend		datetime,
@tds_cushpstr		datetime,
@tds_cushpend		datetime,
@tds_shpqty		int,
@tds_podat		datetime,
@tds_pckunt		nvarchar(6),
@tds_creusr		nvarchar(30)
 

AS

update  TODTLSHP  set	

tds_ftyshpstr = @tds_ftyshpstr,
tds_ftyshpend = @tds_ftyshpend, 
tds_cushpstr = @tds_cushpstr, 
tds_cushpend = @tds_cushpend,
tds_shpqty = @tds_shpqty, 
tds_podat = @tds_podat,
tds_pckunt = @tds_pckunt, 
tds_updusr = @tds_creusr,
 tds_upddat = getdate()
where
--tds_cocde = '' and 
tds_toordno =@tds_toordno and
 tds_toordseq =@tds_toordseq and 
tds_verno = @tds_verno and  
tds_shpseq = @tds_shpseq 


GO
GRANT EXECUTE ON [dbo].[sp_update_TODTLSHP] TO [ERPUSER] AS [dbo]
GO
