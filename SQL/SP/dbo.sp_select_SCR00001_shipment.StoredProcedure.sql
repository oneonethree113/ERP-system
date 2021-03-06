/****** Object:  StoredProcedure [dbo].[sp_select_SCR00001_shipment]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCR00001_shipment]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCR00001_shipment]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








-- Checked by Allan Yuen at 27/07/2003


CREATE  PROCEDURE [dbo].[sp_select_SCR00001_shipment]
@cocde		nvarchar(6),	@ShpFmt		nvarchar(6),
@SCfrom		nvarchar(20),	@SCto		nvarchar(20)

AS


select	@shpfmt as '@shpFmt',
	sds_cocde,
	sds_ordno,
	sds_seq,
	convert(char(10), sds_scfrom, 101) as 'sds_from',
	convert(char(10), sds_scto, 101) as 'sds_to',
	fromMM = replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ltrim(str(datepart(mm,sds_scfrom))),'10','Oct'),'11','Nov'),'12','Dec'),'1','Jan'),'2','Feb'),'3','Mar'),'4','Apr'),'5','May'),'6','Jun'),'7','Jul'),'8','Aug'),'9','Sep'),
	toMM = replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ltrim(str(datepart(mm,sds_scto))),'10','Oct'),'11','Nov'),'12','Dec'),'1','Jan'),'2','Feb'),'3','Mar'),'4','Apr'),'5','May'),'6','Jun'),'7','Jul'),'8','Aug'),'9','Sep'),
 	fromDD = datepart(dd,sds_scfrom) ,
	toDD = datepart(dd,sds_scto),
 	sds_fromYY = ltrim(str(datepart(yyyy,sds_scfrom))) ,
	sds_toYY = ltrim(str(datepart(yyyy,sds_scto))),
	-- David Yue 2013-08-26 Combined SCDTLSHP (old) with SCDTLCTN
	str(sds_ctnstr) as 'sds_ctnstr',
	str(sds_ctnend) as 'sds_ctnend',
	sds_ttlctn,
	str(sds_ttlctn) as 'sds_ttlctn_str',
	-- END OF EDIT
	case sod_contopc when 'Y' then sds_ordqty * sod_conftr else sds_ordqty end as 'sds_ordqty',
	sod_mtrctn,
	qtycol = sds_ttlctn * sod_mtrctn,
	sds_shpseq,
	isnull(sds_dest, '') as 'sds_dest',
	isnull(sds_rmk, '') as 'sds_rmk'
from 	SCDTLSHP (nolock), SCORDDTL (nolock)
where	sds_ordno >= @SCfrom and
	sds_ordno <= @SCto and
	sds_cocde = @cocde and
	sds_ordno = sod_ordno and
	sds_seq = sod_ordseq
order by sds_shpseq








GO
GRANT EXECUTE ON [dbo].[sp_select_SCR00001_shipment] TO [ERPUSER] AS [dbo]
GO
