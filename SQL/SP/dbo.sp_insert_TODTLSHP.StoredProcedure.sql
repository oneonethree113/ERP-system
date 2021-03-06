/****** Object:  StoredProcedure [dbo].[sp_insert_TODTLSHP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_TODTLSHP]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_TODTLSHP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sp_insert_TODTLSHP] 


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

declare @seq int
select @seq =  isnull(max(tds_shpseq) + 1,1) from todtlshp
where
 tds_toordno = @tds_toordno and
 tds_toordseq = @tds_toordseq and
tds_verno = @tds_verno  



insert into	TODTLSHP
(tds_cocde, tds_toordno, tds_toordseq,
 tds_verno, tds_shpseq, tds_ftyshpstr,
 tds_ftyshpend, tds_cushpstr, tds_cushpend,
 tds_shpqty,tds_podat, tds_pckunt, tds_creusr, tds_updusr,
 tds_credat, tds_upddat, tds_timstp)
values
(@tds_cocde,@tds_toordno,@tds_toordseq,
@tds_verno,@seq,@tds_ftyshpstr,
@tds_ftyshpend,@tds_cushpstr,@tds_cushpend,
@tds_shpqty,@tds_podat,@tds_pckunt,@tds_creusr,@tds_creusr,
getdate(),getdate(),null)






GO
GRANT EXECUTE ON [dbo].[sp_insert_TODTLSHP] TO [ERPUSER] AS [dbo]
GO
