/****** Object:  StoredProcedure [dbo].[sp_list_PCR00030]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_PCR00030]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_PCR00030]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO











/*
==================================================================================================================
Program ID	: 	sp_list_PCR00030
Description   	: 	Profit Center Reporting
Programmer  	: 	Marco Chan
ALTER  Date   	: 	20 Sept 2003
Last Modified  	: 
Table Read(s) 	:	
Table Write(s) 	:
==================================================================================================================
 Modification History                                    
==================================================================================================================
Last Update	Updated by		Description
==================================================================================================================
2005-05-13	Lester Wu		Retrieve Company Name from Database
==================================================================================================================
*/
--exec sp_general '㊣PCR00030※L※※01/01/2005 00:00:00.000※01/10/2005 23:59:59※PG※PG※A※A※R※SH※XIJ※HKD', '', '', '', ''
--sp_list_PCR00030 '', '01/01/2004 00:00:00.00', '01/02/2004 23:59:59.99', '', '', '', 'A', '', 'USD'
CREATE        procedure [dbo].[sp_list_PCR00030]
@defCocde nvarchar(6),
@InvDatFm	datetime,
@InvDatTo	datetime,
@CoCdeFm	nvarchar(20),
@CoCdeTo	nvarchar(20),
@PrdVenFm	nvarchar(20),
@PrdVenTo	nvarchar(20),
@InvStatus	nvarchar(1),
@InvType	nvarchar(2),
@VenType	nvarchar(3),
@CurrCde	nvarchar(3)

AS

Begin

declare 
@OptInvDat nvarchar(1),
@OptCoCde nvarchar(1),
@OptVenTyp nvarchar(1),
@OptPrdVen nvarchar(1),
@OptVenTypE nvarchar(1),
@OptVenTypI nvarchar(1),
@OptVenTypJ nvarchar(1)

if @InvDatFm = ''
   set @OptInvDat = 'N'
else
   set @OptInvDat = 'Y'

if @CoCdeFm = ''
   set @OptCoCde = 'N'
else
   set @OptCoCde = 'Y'

if @PrdVenFm = ''
   set @OptPrdVen = 'N'
else
   set @OptPrdVen = 'Y'

if @InvStatus = ''
   set @InvStatus = 'A'

if @InvType=''
   set @InvType = 'A'

if @VenType = ''
   set @OptVenTyp = 'N'
else
begin
   set @OptVenTyp = 'Y'

   if substring(@VenType, 1, 1) = 'E'
	set @OptVenTypE = 'Y'
   else
	set @OptVenTypE = 'N'

   if substring(@VenType, 2, 1) = 'I'
	set @OptVenTypI = 'Y'
   else
	set @OptVenTypI = 'N'

   if substring(@VenType, 3, 1) = 'J'
	set @OptVenTypJ = 'Y'
   else
	set @OptVenTypJ = 'N'

end

if @CurrCde = 'HKD' 
	set @CurrCde = 'HKD'
else
	set @CurrCde = 'USD'


declare @curcde nvarchar(10)
declare @fixbuyrat numeric(16,11)
declare @fixselrat numeric(16,11)

--select @fixbuyrat = ysi_buyrat, @fixselrat = ysi_selrat from SYSETINF where ysi_typ = '06' and ysi_cde = 'HKD'
-- Frankie Cheung 20091012
select @fixbuyrat = yce_buyrat, @fixselrat = yce_selrat from SYCUREX where yce_frmcur = 'HKD' and yce_tocur = 'USD' and yce_iseff = 'Y'


create table #TEMP_RESULT (
   tmp_cocde	nvarchar(6),
   tmp_slnonb	nvarchar(20),
   tmp_invdat	nvarchar(20),
   tmp_invno	nvarchar(20),
   tmp_cusno	nvarchar(12),
   tmp_cussna	nvarchar(20),
   tmp_scno	nvarchar(20),
   tmp_jobno	nvarchar(40),
   tmp_dgnven	nvarchar(6),
   tmp_prdven	nvarchar(6),
   tmp_itmno	nvarchar(20),
   tmp_packing	nvarchar(100),
   tmp_colcde	nvarchar(30),
   tmp_qty	int,
   tmp_untcde	nvarchar(6),
   tmp_untdesc	nvarchar(100),
   tmp_untconvert	numeric(12,4),
   tmp_itmcst	numeric(13,4),
   tmp_purord	nvarchar(40),
   tmp_ttlitmcst	numeric(13,4)
)

create table #RESULT (
   res_cocde	nvarchar(6),
   res_slnonb	nvarchar(20),
   res_invdat	nvarchar(20),
   res_invno	nvarchar(20),
   res_cusno	nvarchar(12),
   res_cussna	nvarchar(20),
   res_screqno	nvarchar(20),
   res_jobno	nvarchar(40),
   res_dv	nvarchar(6),
   res_pv	nvarchar(6),
   res_itmno	nvarchar(20),
   res_packing	nvarchar(100),
   res_colcde	nvarchar(30),
   res_qty	int,
   res_untcde	nvarchar(6),
   res_untdesc	nvarchar(100),
   res_untconvert	numeric(12,4),
   res_untcst	numeric(13,4),
   res_pono	nvarchar(40),
   res_ttlitmcst	numeric(13,4)
)


declare @cocde nvarchar(6), @type nvarchar(2), @docno nvarchar(20)

Declare cur_Invoice cursor
for
--Extract Invoice
Select	distinct hiv_cocde, 'SH', hiv_invno--, hiv_invdat
From	SHIPGHDR (nolock)
	left join SHIPGDTL (nolock) on hih_cocde = hid_cocde and hih_shpno = hid_shpno
	left join SHINVHDR (nolock) on hih_cocde = hiv_cocde and hid_shpno = hiv_shpno and hid_invno = hiv_invno
	left join SHDISPRM (nolock) on hih_cocde = hdp_cocde and hiv_invno = hdp_invno and hiv_invno = hdp_invno
	left join SYDISPRM (nolock) on hdp_type = ydp_type and hdp_cde = ydp_cde
	left join SCORDHDR (nolock) on soh_cocde = hid_cocde and soh_ordno = hid_ordno
	
where	
	hiv_invsts <> 'C' 
	and  ((@InvStatus='A' ) or (@InvStatus='R' and hih_shpsts='REL'))
	and (@OptInvDat = 'N' or (hiv_invdat between @InvDatFm and @InvDatTo))
	and (@InvType in ('A' ,'SH'))
Union
Select 	distinct sih_cocde, 'SA', sih_invno--, sih_issdat
From	SAINVHDR (nolock) 
	left join SAINVDTL (nolock) on sih_cocde = sid_cocde and sih_invno = sid_invno
	left join CUPRCINF (nolock) on sih_cus1no = cpi_cusno
Where	sih_invno <> '' 
	and ((@InvStatus='A' and (sih_invsts = 'REL' or sih_invsts = 'CLO')) or (@InvStatus='R' and sih_invsts='REL'))
	and (@OptInvDat = 'N' or (sih_issdat between @InvDatFm and @InvDatTo))
	and (@InvType in ('A','SA'))

order by	2, 1, 3

Open cur_Invoice
Fetch next from cur_Invoice into
@cocde,
@type,
@docno

While @@fetch_status = 0
Begin
--	select @cocde, @type, @docno, getdate()
--	print @cocde + ' : ' + @type + ' : ' + @docno + ' : ' + 'Marco001' + convert(varchar(50), getdate(), 109)

	If @type = 'SH'
	begin
		-- Get SHIPGDTL into #TEMP_RESULT_DTL (ibi_itmno)
		insert into #TEMP_RESULT
		select 	hiv.hiv_cocde,
			isnull(convert(nvarchar(20),hih.hih_slnonb,101), ''),
			isnull(convert(nvarchar(20),hiv.hiv_invdat,101), ''),
			isnull(hiv.hiv_invno,''),
			hih.hih_cus1no,
			cbi.cbi_cussna,
			hid.hid_ordno,
			hid.hid_jobno,
			isnull(ibi.ibi_venno, ''),
			case hid.hid_venno when '0005' then 
						case sod.sod_subcde when 'WTX' then 'B'
								    when 'WY' then 'C'
								    when '0007' then 'D'
								    when 'HE' then 'E'
								    when 'HEC' then 'E'
								    when 'FC' then 'F'
								    when 'UGIL' then 'G'
								    when 'HY' then 'H'
								    when 'WM' then 'J'
								    when 'WB' then 'K'
								    when 'LW' then 'L'
								    when 'TY' then 'T'
								    else 'A' end
					   when '0006' then 'H'
					   else isnull(hid.hid_venno, '') end,
			hid.hid_itmno,
			convert(varchar(50), hid.hid_inrctn) + ' / ' + convert(varchar(50), hid.hid_mtrctn) + ' / ' + convert(varchar(50), hid.hid_vol),
			hid.hid_colcde, 
			hid.hid_shpqty,
			hid.hid_untcde, 
			ycf.ycf_dsc1,
			ycf.ycf_value,
--			case poh.poh_curcde when 'HKD' then (isnull(pod.pod_ftyprc,0)*(1.00 - isnull(poh.poh_discnt,0)/100.00)) * curpo.ysi_buyrat
--						else (isnull(pod.pod_ftyprc,0)*(1.00 - isnull(poh.poh_discnt,0)/100.00)) end,
			(isnull(pod.pod_ftyprc,0)*(1.00 - isnull(poh.poh_discnt,0)/100.00)) * curpo.yce_buyrat,
			hid.hid_purord,
			0 --(case poh.poh_curcde when 'HKD' then (isnull(pod.pod_ftyprc,0)*(1.00 - isnull(poh.poh_discnt,0)/100.00)) * curpo.ysi_buyrat
				--		else (isnull(pod.pod_ftyprc,0)*(1.00 - isnull(poh.poh_discnt,0)/100.00)) end ) * hid.hid_shpqty
		from
			SHIPGHDR hih (nolock)
			left join SHIPGDTL hid (nolock) on hih.hih_cocde = hid.hid_cocde and hih.hih_shpno = hid.hid_shpno
			left join SHINVHDR hiv (nolock) on hih.hih_cocde = hiv.hiv_cocde and hid.hid_shpno = hiv.hiv_shpno and hid.hid_invno = hiv.hiv_invno

			left join SCORDDTL sod (nolock) on sod.sod_cocde = hid.hid_cocde and sod_ordno = hid_ordno and sod_ordseq = hid_ordseq

			left join POORDDTL pod (nolock) on pod.pod_cocde = hid.hid_cocde
							and pod.pod_purord = hid.hid_purord
							and pod.pod_purseq = hid.hid_purseq

			left join POORDHDR poh (nolock) on pod.pod_cocde = poh.poh_cocde
							and pod.pod_purord = poh.poh_purord
	
			left join IMBASINF ibi (nolock) on hid.hid_itmno = ibi.ibi_itmno and ibi_itmsts <> 'CLO'

			left join VNBASINF vbi (nolock) on vbi.vbi_venno = hid.hid_venno	-- get the vendor type of production vendor

--			left join SYSETINF curpo (nolock) on curpo.ysi_cde = poh.poh_curcde and curpo.ysi_typ = '06'
			-- Frankie Cheung 20091012
			left join SYCUREX curpo (nolock) on curpo.yce_frmcur = poh.poh_curcde and curpo.yce_tocur = 'USD' and curpo.yce_iseff = 'Y'

			left join CUBASINF cbi (nolock) on cbi.cbi_cusno = hih.hih_cus1no

			left join SYCONFTR ycf (nolock) on ycf.ycf_code1 = hid.hid_untcde
		where 
			hiv.hiv_cocde = @cocde and
			hih.hih_shpsts in ('OPE','REL') and
			hiv.hiv_invsts <> 'C' and
			hiv.hiv_invno = @docno and
			hiv.hiv_invamt <> 0
			and ibi.ibi_venno not in ('0005','0006','0007','0008','0009')
			and (@OptCoCde = 'N' or (hiv_cocde between @CoCdeFm and @CoCdeTo))
			and (@OptVenTyp = 'N' or ((@OptVenTypE='Y' and vbi.vbi_ventyp='E') or (@OptVenTypI='Y' and vbi.vbi_ventyp='I') or (@OptVenTypJ='Y' and vbi.vbi_ventyp='J')))



		-- Get SHIPGDTL into #TEMP_RESULT_DTL (ibi_alsitmno)
		insert into #TEMP_RESULT
		select 	hiv.hiv_cocde,
			isnull(convert(nvarchar(20),hih.hih_slnonb,101), ''),
			isnull(convert(nvarchar(20),hiv.hiv_invdat,101), ''),
			isnull(hiv.hiv_invno,''),
			hih.hih_cus1no,
			cbi.cbi_cussna,
			hid.hid_ordno,
			hid.hid_jobno,
			isnull(ibi.ibi_venno, ''),
			case hid.hid_venno when '0005' then 
						case sod.sod_subcde when 'WTX' then 'B'
								    when 'WY' then 'C'
								    when '0007' then 'D'
								    when 'HE' then 'E'
								    when 'HEC' then 'E'
								    when 'FC' then 'F'
								    when 'UGIL' then 'G'
								    when 'HY' then 'H'
								    when 'WM' then 'J'
								    when 'WB' then 'K'
								    when 'LW' then 'L'
								    when 'TY' then 'T'
								    else 'A' end
					   when '0006' then 'H'
					   else isnull(hid.hid_venno, '') end,
			hid.hid_itmno,
			convert(varchar(50), hid.hid_inrctn) + ' / ' + convert(varchar(50), hid.hid_mtrctn) + ' / ' + convert(varchar(50), hid.hid_vol),
			hid.hid_colcde, 
			hid.hid_shpqty,
			hid.hid_untcde, 
			ycf.ycf_dsc1,
			ycf.ycf_value,
--			case poh.poh_curcde when 'HKD' then (isnull(pod.pod_ftyprc,0)*(1.00 - isnull(poh.poh_discnt,0)/100.00)) * curpo.ysi_buyrat
--						else (isnull(pod.pod_ftyprc,0)*(1.00 - isnull(poh.poh_discnt,0)/100.00)) end,
			-- Frankie Cheung 20091012
			(isnull(pod.pod_ftyprc,0)*(1.00 - isnull(poh.poh_discnt,0)/100.00)) * curpo.yce_buyrat,

			hid.hid_purord,
			0 --(case poh.poh_curcde when 'HKD' then (isnull(pod.pod_ftyprc,0)*(1.00 - isnull(poh.poh_discnt,0)/100.00)) * curpo.ysi_buyrat
				--		else (isnull(pod.pod_ftyprc,0)*(1.00 - isnull(poh.poh_discnt,0)/100.00)) end ) * hid.hid_shpqty
		from
			SHIPGHDR hih (nolock)
			left join SHIPGDTL hid (nolock) on hih.hih_cocde = hid.hid_cocde and hih.hih_shpno = hid.hid_shpno
			left join SHINVHDR hiv (nolock) on hih.hih_cocde = hiv.hiv_cocde and hid.hid_shpno = hiv.hiv_shpno and hid.hid_invno = hiv.hiv_invno

			left join SCORDDTL sod (nolock) on sod.sod_cocde = hid.hid_cocde and sod_ordno = hid_ordno and sod_ordseq = hid_ordseq

			left join POORDDTL pod (nolock) on pod.pod_cocde = hid.hid_cocde
							and pod.pod_purord = hid.hid_purord
							and pod.pod_purseq = hid.hid_purseq

			left join POORDHDR poh (nolock) on pod.pod_cocde = poh.poh_cocde
							and pod.pod_purord = poh.poh_purord
	
			left join IMBASINF ibi (nolock) on hid.hid_itmno = ibi.ibi_alsitmno and ibi_itmsts <> 'CLO'
			
			--Added by Mark Lau 20070727
			left join imbasinf als on als.ibi_itmno = ibi.ibi_alsitmno 
			
			left join VNBASINF vbi (nolock) on vbi.vbi_venno = hid.hid_venno	-- get the vendor type of production vendor

--			left join SYSETINF curpo (nolock) on curpo.ysi_cde = poh.poh_curcde and curpo.ysi_typ = '06'
			left join SYCUREX curpo (nolock) on curpo.yce_frmcur = poh.poh_curcde and curpo.yce_tocur = 'USD' and curpo.yce_iseff = 'Y' 

			left join CUBASINF cbi (nolock) on cbi.cbi_cusno = hih.hih_cus1no

			left join SYCONFTR ycf (nolock) on ycf.ycf_code1 = hid.hid_untcde
		where 
			hiv.hiv_cocde = @cocde and 
			hih.hih_shpsts in ('OPE','REL') and
			hiv.hiv_invsts <> 'C' and
			hiv.hiv_invno = @docno and
			hiv.hiv_invamt <> 0
			and ibi.ibi_venno not in ('0005','0006','0007','0008','0009')
			and (@OptCoCde = 'N' or (hiv_cocde between @CoCdeFm and @CoCdeTo))
			and (@OptVenTyp = 'N' or ((@OptVenTypE='Y' and vbi.vbi_ventyp='E') or (@OptVenTypI='Y' and vbi.vbi_ventyp='I') or (@OptVenTypJ='Y' and vbi.vbi_ventyp='J')))
			and als.ibi_itmsts <> 'OLD'
	end
	else if @type = 'SA'
	begin
		-- Sample Invoice (ibi_itmno)
		insert into #TEMP_RESULT
		select 	
			sih.sih_cocde,
			'', -- sailing date
			isnull(convert(nvarchar(20),sih.sih_issdat,101), ''),
			isnull( sih.sih_invno,''),
			sih.sih_cus1no,
			cbi.cbi_cussna,
			sid.sid_reqno, -- Req Number
			'', -- Job No.
			isnull(ibi.ibi_venno, ''),-- Design Vendor
			case sid.sid_venno when '0005' then 
						case sid.sid_subcde when 'WTX' then 'B'
								    when 'WY' then 'C'
								    when '0007' then 'D'
								    when 'HE' then 'E'
								    when 'HEC' then 'E'
								    when 'FC' then 'F'
								    when 'UGIL' then 'G'
								    when 'HY' then 'H'
								    when 'WM' then 'J'
								    when 'WB' then 'K'
								    when 'LW' then 'L'
								    when 'TY' then 'T'
								    else 'A' end
					   when '0006' then 'H'
					   else isnull(sid.sid_venno, '') end,-- Production Vendor
			sid.sid_itmno,
			convert(varchar(50), sid.sid_inrqty) + ' / ' + convert(varchar(50), sid.sid_mtrqty) + ' / ' + convert(varchar(50), sid.sid_cft),
			sid.sid_colcde, 
			sid.sid_chgqty, -- Qty
			sid.sid_untcde, -- UM
			ycf.ycf_dsc1,
			ycf.ycf_value,
--			case sid.sid_fcurcde when 'HKD' then isnull(sid.sid_ftyprc, 0) * fcur.ysi_buyrat
--							else isnull(sid.sid_ftyprc, 0) end,
			-- Frankie Cheung 20091012
			isnull(sid.sid_ftyprc, 0) * fcur.yce_buyrat,
			'',
			0 --(case sid.sid_fcurcde when 'HKD' then isnull(sid.sid_ftyprc, 0) * fcur.ysi_buyrat
				--			else isnull(sid.sid_ftyprc, 0) end ) * sid.sid_chgqty
		from SAINVHDR sih (nolock)
		left join SAINVDTL sid (nolock) on sih.sih_cocde = sid.sid_cocde and sih.sih_invno = sid.sid_invno
		left join IMBASINF ibi (nolock) on sid.sid_itmno = ibi.ibi_itmno and ibi_itmsts <> 'CLO'
		left join IMVENINF ivi (nolock) on ivi_itmno = ibi.ibi_itmno and ivi_def = 'Y'
		left join VNBASINF vbi (nolock) on vbi.vbi_venno = sid.sid_venno
--		left join SYSETINF fcur (nolock) on fcur.ysi_cde = sid.sid_fcurcde and fcur.ysi_typ = '06'
		-- Frankie Cheung 20091012
		left join SYCUREX fcur (nolock) on fcur.yce_frmcur = sid.sid_fcurcde and fcur.yce_tocur = 'USD' and fcur.yce_iseff = 'Y'
		left join CUBASINF cbi (nolock) on cbi.cbi_cusno = sih.sih_cus1no
		left join SYCONFTR ycf (nolock) on ycf.ycf_code1 = sid.sid_untcde
		where sih_cocde = @cocde and sih_invno = @docno
			and sih_netamt > 0
			and ibi.ibi_venno not in ('0005','0006','0007','0008','0009')
			and (@OptCoCde = 'N' or (sih_cocde between @CoCdeFm and @CoCdeTo))
			and (@OptVenTyp = 'N' or ((@OptVenTypE='Y' and vbi.vbi_ventyp='E') or (@OptVenTypI='Y' and vbi.vbi_ventyp='I') or (@OptVenTypJ='Y' and vbi.vbi_ventyp='J')))


		-- Sample Invoice (ibi_alsitmno)
		insert into #TEMP_RESULT
		select 	
			sih.sih_cocde,
			'', -- sailing date
			isnull(convert(nvarchar(20),sih.sih_issdat,101), ''),
			isnull( sih.sih_invno,''),
			sih.sih_cus1no,
			cbi.cbi_cussna,
			sid.sid_reqno, -- Req Number
			'', -- Job No.
			isnull(ibi.ibi_venno, ''),-- Design Vendor
			case sid.sid_venno when '0005' then 
						case sid.sid_subcde when 'WTX' then 'B'
								    when 'WY' then 'C'
								    when '0007' then 'D'
								    when 'HE' then 'E'
								    when 'HEC' then 'E'
								    when 'FC' then 'F'
								    when 'UGIL' then 'G'
								    when 'HY' then 'H'
								    when 'WM' then 'J'
								    when 'WB' then 'K'
								    when 'LW' then 'L'
								    when 'TY' then 'T'
								    else 'A' end
					   when '0006' then 'H'
					   else isnull(sid.sid_venno, '') end,-- Production Vendor
			sid.sid_itmno,
			convert(varchar(50), sid.sid_inrqty) + ' / ' + convert(varchar(50), sid.sid_mtrqty) + ' / ' + convert(varchar(50), sid.sid_cft),
			sid.sid_colcde, 
			sid.sid_chgqty, -- Qty
			sid.sid_untcde, -- UM
			ycf.ycf_dsc1,
			ycf.ycf_value,
--			case sid.sid_fcurcde when 'HKD' then isnull(sid.sid_ftyprc, 0) * fcur.ysi_buyrat
--							else isnull(sid.sid_ftyprc, 0) end,
			-- Frankie Cheung 20091012
			isnull(sid.sid_ftyprc, 0) * fcur.yce_buyrat,
			'',
			0 --(case sid.sid_fcurcde when 'HKD' then isnull(sid.sid_ftyprc, 0) * fcur.ysi_buyrat
				--			else isnull(sid.sid_ftyprc, 0) end ) * sid.sid_chgqty
		from SAINVHDR sih (nolock)
		left join SAINVDTL sid (nolock) on sih.sih_cocde = sid.sid_cocde and sih.sih_invno = sid.sid_invno
		left join IMBASINF ibi (nolock) on sid.sid_itmno = ibi.ibi_alsitmno and ibi_itmsts <> 'CLO'

			--Added by Mark Lau 20070727
			left join imbasinf als on als.ibi_itmno = ibi.ibi_alsitmno 

		left join IMVENINF ivi (nolock) on ivi_itmno = ibi.ibi_itmno and ivi_def = 'Y'
		left join VNBASINF vbi (nolock) on vbi.vbi_venno = sid.sid_venno
--		left join SYSETINF fcur (nolock) on fcur.ysi_cde = sid.sid_fcurcde and fcur.ysi_typ = '06'
		-- Frankie Cheung 20091012
		left join SYCUREX fcur (nolock) on fcur.yce_frmcur = sid.sid_fcurcde and fcur.yce_tocur = 'USD' and fcur.yce_iseff = 'Y'

		left join CUBASINF cbi (nolock) on cbi.cbi_cusno = sih.sih_cus1no
		left join SYCONFTR ycf (nolock) on ycf.ycf_code1 = sid.sid_untcde
		where sih_cocde = @cocde and sih_invno = @docno
			and sih_netamt > 0
			and ibi.ibi_venno not in ('0005','0006','0007','0008','0009')
			and (@OptCoCde = 'N' or (sih_cocde between @CoCdeFm and @CoCdeTo))
			and (@OptVenTyp = 'N' or ((@OptVenTypE='Y' and vbi.vbi_ventyp='E') or (@OptVenTypI='Y' and vbi.vbi_ventyp='I') or (@OptVenTypJ='Y' and vbi.vbi_ventyp='J')))
			and als.ibi_itmsts <> 'OLD'
	end

	insert into #RESULT
	select tmp_cocde, tmp_slnonb, tmp_invdat, tmp_invno,tmp_cusno, tmp_cussna, tmp_scno, tmp_jobno,
		tmp_dgnven, tmp_prdven, tmp_itmno, tmp_packing, tmp_colcde,
		sum(tmp_qty), tmp_untcde, tmp_untdesc, tmp_untconvert, tmp_itmcst, tmp_purord, sum(tmp_ttlitmcst)
	from #TEMP_RESULT
	group by tmp_cocde, tmp_slnonb, tmp_invdat, tmp_invno,tmp_cusno, tmp_cussna, tmp_scno, tmp_jobno,
		tmp_dgnven, tmp_prdven, tmp_itmno, tmp_packing, tmp_colcde,
		tmp_untcde, tmp_untdesc, tmp_untconvert, tmp_itmcst, tmp_purord

	delete from #TEMP_RESULT

	Fetch next from cur_Invoice into
	@cocde,
	@type,
	@docno
end
close cur_Invoice
deallocate cur_Invoice


if @CurrCde = 'HKD' 
begin
--update #RESULT set res_untcst = res_untcst / @fixbuyrat, res_ttlitmcst = res_ttlitmcst / @fixbuyrat
update #RESULT set res_untcst = res_untcst / @fixbuyrat
end

--
update #RESULT set  res_ttlitmcst = res_untcst*res_qty
--


select 
convert(nvarchar(10),@InvDatFm,101),
convert(nvarchar(10),@InvDatTo,101),
@CoCdeFm,
@CoCdeTo,
@PrdVenFm,
@PrdVenTo,
@InvStatus,
@InvType,
@VenType,
@CurrCde,
res_cocde,
res_slnonb,
res_invno,
res_invdat,
res_cusno,
res_cussna,
res_screqno,
res_jobno,
res_dv,
res_pv,
res_itmno,
res_packing,
res_colcde,
res_qty,
res_untcde,
res_untdesc,
res_untconvert,
res_untcst,
res_pono,
convert(varchar(20), res_ttlitmcst),
res_ttlitmcst, 
isnull(yco_conam,'') 'compName'	--Lester Wu 2005-05-13, retrieve company name from database
from #RESULT
left join SYCOMINF on res_cocde = yco_cocde
where (@OptPrdVen = 'N' or (res_pv between @PrdVenFm and @PrdVenTo))
order by res_cocde, res_invdat, res_cusno,res_invno, res_jobno


end




GO
GRANT EXECUTE ON [dbo].[sp_list_PCR00030] TO [ERPUSER] AS [dbo]
GO
