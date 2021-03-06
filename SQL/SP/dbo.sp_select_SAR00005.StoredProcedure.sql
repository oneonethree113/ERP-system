/****** Object:  StoredProcedure [dbo].[sp_select_SAR00005]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SAR00005]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SAR00005]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO











-- Modificatin History
-- Modified By		Modified On		Description
-- Lester Wu 		Mar 31 , 2004		Return 'bolShpMrk' to indicate the available of sih_shprmk
--						since memo type cannot be used in formula field in crystal report
-- Lester Wu		Apr 03 , 2004		Return Detail Remark Field
-- Lester Wu		Mar 14, 2004		Retrieve Company Name, Short Name, Address, Phone No, Fax No Logo Path
CREATE   PROCEDURE [dbo].[sp_select_SAR00005]
@cocde		nvarchar(6),	
@SARfm		nvarchar(20),	@SARto		nvarchar(20),
@printGroup	nvarchar(1),	@printAlias	nvarchar(1)

AS

------------------------------------------------------------------------------------------------------------------------------------------------------
--Lester Wu 2005/03/03 -- Retrieve Company Name, Short Name, Address, Phone No, Fax No,  Logo Path
------------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE
@yco_conam	varchar(100),
@yco_shtnam	varchar(25),
@yco_addr		varchar(200),

@yco_conamc	nvarchar(100),
@yco_shtnamc	nvarchar(25),
@yco_addrc	nvarchar(200),

@yco_phoneno	varchar(50),
@yco_faxno	varchar(50),
@yco_logoimgpth	varchar(100)

set @yco_conam = ''
set @yco_shtnam = ''
set @yco_addr = ''

set @yco_conamc = ''
set @yco_shtnamc = ''
set @yco_addrc = ''

set @yco_phoneno = ''
set @yco_faxno = ''

set @yco_logoimgpth = ''

select
@yco_conam=yco_conam,
@yco_shtnam=yco_shtnam,
@yco_addr=yco_addr,

@yco_conamc = yco_conamc,
@yco_shtnamc = yco_shtnamc,
@yco_addrc = yco_addrc,

@yco_phoneno= yco_phoneno,
@yco_faxno = yco_faxno,
@yco_logoimgpth = yco_logoimgpth
from 
SYCOMINF(NOLOCK)
where
yco_cocde = @cocde
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

 select
	-- SAINVHDR 
	sih_cocde,		sih_curcde,		sih_salrep,
	sih_invno,		sih_cus1no,		sih_cus1ad,		
	sih_cus1st,		sih_cus1cy,		sih_cus1zp,
	sih_cus1cp,	sih_courier,		sih_ttlamt,
	case when len(isnull(sih_shprmk,'')) > 0 then 'Y' else '' end as 'bolShipRmk',	
	sih_rmk,			sih_hdrrmk,
	sih_doctyp,	sih_docno,

	-- SYSALREP
	sysalrep = ysr_dsc,

	-- SAINVDTL
	--sid_itmno,		
	--Added by Mark Lau 20060924
		--Added by Mark Lau 20080516, Add CDTVX
		case when @printGroup = '1'  then
		
		-- Changed by Mark Lau 20090402, use function to perform the logic
		/*		
		case when len(sid_itmno) < 11 or charindex('-',sid_itmno) > 0 or charindex('/',sid_itmno) >0 or (Upper(substring(sid_itmno,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(sid_itmno,7,2) = 'AS' then sid_itmno
	
		else 
		case when upper(substring(sid_itmno, 3, 1)) = 'A' or upper(substring(sid_itmno, 3, 1)) = 'C'  or upper(substring(sid_itmno, 3, 1)) = 'D' or upper(substring(sid_itmno, 3, 1)) = 'T' or upper(substring(sid_itmno, 3, 1)) = 'X' or upper(substring(sid_itmno, 3, 1)) = 'V'  then substring(sid_itmno,1,11)--and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)

			else 
			case when upper(substring(sid_itmno, 3, 1)) = 'B' and (substring(sid_itmno, 4, 1) >= '0' And substring(sid_itmno, 4, 1) <= '9' ) And (substring(sid_itmno, 5, 1) >= '0' And substring(sid_itmno, 5, 1) <= '9' ) And  (substring(sid_itmno, 6, 1) >= '0' And substring(sid_itmno, 6, 1) <= '9') then substring(sid_itmno,1,11)
				else 
				case when upper(substring(sid_itmno, 3, 1)) = 'B' and (upper(substring(sid_itmno, 4, 1)) >= 'A' And upper(substring(sid_itmno, 4, 1)) <= 'Z' ) And (substring(sid_itmno, 5, 1) >= '0' And substring(sid_itmno, 5, 1) <= '9' ) And  (substring(sid_itmno, 6, 1) >= '0' And substring(sid_itmno, 6, 1) <= '9') then substring(sid_itmno,1,11)
					else sid_itmno
				 end
			end
		end
		end
		*/
		dbo.groupnewitmno(sid_itmno)
		else
		sid_itmno
		end as 'sid_itmno',
	case when @printAlias = "1" then sid_alsitmno else '' end as 'sid_alsitmno',

	sid_cusitm,		sid_itmdsc,
	--sid_cuscol,		

--Added by Mark Lau 20060924
		--Added by Mark Lau 20080516, Add CDTVX
		case when @printGroup = '1'  then

		-- Changed by Mark Lau 20090402, use function to perform the logic
		/*			
		case when len(sid_itmno) < 11 or charindex('-',sid_itmno) > 0 or charindex('/',sid_itmno) >0 or (Upper(substring(sid_itmno,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(sid_itmno,7,2) = 'AS' then sid_cuscol
	
		else 
		case when upper(substring(sid_itmno, 3, 1)) = 'A'   or upper(substring(sid_itmno, 3, 1)) = 'C'  or upper(substring(sid_itmno, 3, 1)) = 'D' or upper(substring(sid_itmno, 3, 1)) = 'T' or upper(substring(sid_itmno, 3, 1)) = 'X' or upper(substring(sid_itmno, 3, 1)) = 'V'  then + '(' + substring(sid_itmno,12, len(sid_itmno) - 11) +  ') ' + sid_cuscol   --and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)
			else 
			case when upper(substring(sid_itmno, 3, 1)) = 'B' and (substring(sid_itmno, 4, 1) >= '0' And substring(sid_itmno, 4, 1) <= '9' ) And (substring(sid_itmno, 5, 1) >= '0' And substring(sid_itmno, 5, 1) <= '9' ) And  (substring(sid_itmno, 6, 1) >= '0' And substring(sid_itmno, 6, 1) <= '9') then  '(' +  substring(sid_itmno,12,len(sid_itmno) - 11) + ') ' + sid_cuscol
				else 
				case when upper(substring(sid_itmno, 3, 1)) = 'B' and (upper(substring(sid_itmno, 4, 1)) >= 'A' And upper(substring(sid_itmno, 4, 1)) <= 'Z' ) And (substring(sid_itmno, 5, 1) >= '0' And substring(sid_itmno, 5, 1) <= '9' ) And  (substring(sid_itmno, 6, 1) >= '0' And substring(sid_itmno, 6, 1) <= '9') then  '(' + substring(sid_itmno,12,len(sid_itmno) - 11) + ') ' + sid_cuscol
					else sid_cuscol
				 end
			end
		end
		end	
		*/
		dbo.groupnewitmcol(sid_itmno,' (' + sid_venno + ') ' + sid_cuscol,'Y')


		else
		' (' + sid_venno + ') ' + sid_cuscol
		end as 'sid_cuscol',


	sid_coldsc,			

	


	sid_colcde,		
	sid_pckunt,		
	sid_inrqty,		sid_inrqtyStr = str(sid_inrqty),
	sid_mtrqty,	sid_mtrqtyStr = str(sid_mtrqty),
	sid_cft,		sid_cftStr = str(sid_cft),
	sid_selprc,
	sid_untcde,	sid_ttlamt,			sid_smpunt,
	sid_shpqty,	sid_shpqtyStr = str(sid_shpqty),
	sid_chgqty,	sid_chgqtyStr = str(sid_chgqty),
	packing = ltrim(str(isNull(sid_inrqty,0),10,0)) + ltrim(str(isNUll(sid_mtrqty,0),10,0)) + ltrim(str(isNull(sid_cft,0),10,2)) + ltrim(isNull(sid_pckunt,'')),

	-- CUBASINF	
	pri.cbi_cussna,		pri.cbi_cusnam,

	-- SYSETINF
	sysPrc.ysi_dsc,	sysPck.ysi_dsc,	sysSmp.ysi_dsc,	sysUnt.ysi_dsc,	sysCy.ysi_dsc,

	round((select sum(sid_ttlamt) from SAINVDTL b where b.sid_cocde = a.sid_cocde and b.sid_invno = a.sid_invno and b.sid_itmno = a.sid_itmno and
	b.sid_selprc = a.sid_selprc and b.sid_inrqty = a.sid_inrqty and b.sid_mtrqty = a.sid_mtrqty and b.sid_untcde = a.sid_untcde),2),

	isnull(sec.cbi_cusnam, ''),
	--case isnull(yst_charge,'') when 'P' then isnull(yst_chgval,0) else 0 end,
	isnull(sih_discnt,0),
	isnull(sih_netamt,''),

	sih_issdat,
	sih_rvsdat
	,sih_shprmk
	,case when len(isnull(sid_rmk,'')) > 0 then 'Y' else 'N' end as bolSidRmk
	,sid_rmk,
	--,case when len(isnull(sih_docno,'')) > 0 then 'Y' else 'N' end as bolDocNo,
/*	round((select sum(sid_ttlamt) from SAINVDTL b where b.sid_cocde = a.sid_cocde and b.sid_invno = a.sid_invno and b.sid_itmno = a.sid_itmno and
	b.sid_colcde = a.sid_colcde and b.sid_inrqty = a.sid_inrqty and b.sid_mtrqty = a.sid_mtrqty and b.sid_untcde = a.sid_untcde),2) as 'ttlamt'*/

	--Lester Wu 2005-03-14 Return Company Name, Address, Phone No, Fax
	@yco_conam	as 'CompName',
	@yco_addr	as 'CompAddr',
	@yco_phoneno	as 'CompPhone',
	@yco_faxno	as 'CompFAX',
	@yco_logoimgpth	as 'CompLogo'
	----------------------------------------------------------------------------------------------------------------------

	--Added by Mark Lau 20060924
	,@printGroup
	,--Added by Mark Lau 20060924
		--Added by Mark Lau 20080516, Add CDTVX
		case when @printGroup = '1'  then

		-- Changed by Mark Lau 20090402, use function to perform the logic
		/*	
		case when len(sid_itmno) < 11 or charindex('-',sid_itmno) > 0 or charindex('/',sid_itmno) >0 or (Upper(substring(sid_itmno,3,1)) not in ('A','B','U','C','D','T','V','X')) or substring(sid_itmno,7,2) = 'AS' then ''
	
		else 
		case when upper(substring(sid_itmno, 3, 1)) = 'A' or upper(substring(sid_itmno, 3, 1)) = 'C'  or upper(substring(sid_itmno, 3, 1)) = 'D' or upper(substring(sid_itmno, 3, 1)) = 'T' or upper(substring(sid_itmno, 3, 1)) = 'X' or upper(substring(sid_itmno, 3, 1)) = 'V'  then + '(' + substring(sid_itmno,12, len(sid_itmno) - 11) +  ') ' +  ''   --and (substring(dtl.qud_itmno, 4, 1) >= '0' And substring(dtl.qud_itmno, 4, 1) <= '9' ) And (substring(dtl.qud_itmno, 5, 1) >= '0' And substring(dtl.qud_itmno, 5, 1) <= '9' ) And  (substring(dtl.qud_itmno, 6, 1) >= '0' And substring(dtl.qud_itmno, 6, 1) <= '9') then substring(dtl.qud_itmno,1,11)
			else 
			case when upper(substring(sid_itmno, 3, 1)) = 'B' and (substring(sid_itmno, 4, 1) >= '0' And substring(sid_itmno, 4, 1) <= '9' ) And (substring(sid_itmno, 5, 1) >= '0' And substring(sid_itmno, 5, 1) <= '9' ) And  (substring(sid_itmno, 6, 1) >= '0' And substring(sid_itmno, 6, 1) <= '9') then  '(' +  substring(sid_itmno,12,len(sid_itmno) - 11) + ') ' +  ''
				else 
				case when upper(substring(sid_itmno, 3, 1)) = 'B' and (upper(substring(sid_itmno, 4, 1)) >= 'A' And upper(substring(sid_itmno, 4, 1)) <= 'Z' ) And (substring(sid_itmno, 5, 1) >= '0' And substring(sid_itmno, 5, 1) <= '9' ) And  (substring(sid_itmno, 6, 1) >= '0' And substring(sid_itmno, 6, 1) <= '9') then  '(' + substring(sid_itmno,12,len(sid_itmno) - 11) + ') ' +  ''
					else  ''
				 end
			end
		end
		end
		*/
		case when dbo.groupnewitmcol(sid_itmno,'','N') = '' then '' else '(' +  dbo.groupnewitmcol(sid_itmno,'','N') + ') '  end
		else
		 ''
		end as 'ColSeq'

--Kenny Re-Write on 20-11-2002
from 		SAINVHDR
left join CUBASINF pri on sih_cus1no = pri.cbi_cusno --and pri.cbi_cocde = sih_cocde 
left join  	CUBASINF sec on-- sih_cocde = sec.cbi_cocde and
		 sih_cus2no = sec.cbi_cusno
--left join SYSALREP on sih_salrep = ysr_code1 --and sih_cocde = ysr_cocde
left join SYSALREP on sih_srname = ysr_code --and sih_cocde = ysr_cocde
left join SAINVDTL a on sih_cocde = sid_cocde and sih_invno = sid_invno 
left join SYSETINF sysCY on --sih_cocde = sysCy.ysi_cocde and 
		sysCy.ysi_typ = '02' and sih_cus1cy = sysCy.ysi_cde
left join SYSETINF sysPrc on --sih_cocde = sysPrc.ysi_cocde and 
		sysPrc.ysi_typ = '03' and sih_prctrm = sysPrc.ysi_cde
left join SYSETINF sysPck on --sid_cocde = sysPck.ysi_cocde and 
		sysPck.ysi_typ = '05' and sid_pckunt = sysPck.ysi_cde
left join SYSETINF sysSmp on --sid_cocde = sysSmp.ysi_cocde and 
		sysSmp.ysi_typ = '05' and sid_smpunt = sysSmp.ysi_cde
left join SYSETINF sysUnt on --sid_cocde = sysUnt.ysi_cocde and 
		sysUnt.ysi_typ = '05' and sid_untcde = sysUnt.ysi_cde
left join SYSMPTRM on --sih_cocde = yst_cocde and 
		sih_smpprd = yst_trmcde

where sih_cocde = @cocde
and 	sih_invno >= @SARfm and sih_invno <= @SARto
order by sih_invno, sid_itmno, sid_selprc, ColSeq





GO
GRANT EXECUTE ON [dbo].[sp_select_SAR00005] TO [ERPUSER] AS [dbo]
GO
