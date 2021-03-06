/****** Object:  StoredProcedure [dbo].[sp_select_SAR00006]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SAR00006]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SAR00006]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO












/****** Object:  Stored Procedure dbo.sp_select_SAR00006    Script Date: 04/04/2003 12:10:23 ******/
/*
=========================================================
Program ID	: sp_select_SAR00006
Description   	: Sample Request Printing
Programmer  	: 
ALTER  Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
Date		Initial		Description
=========================================================
4 Apr 2003		Lewis To		Add filter for cancel Flag = 'Y'
24 Mar 2004	Lester Wu		Allow Sort by Input Sequence
01 Apr 2004	Lester Wu		Return External Vendor's contact name, tel and fax if available 
				Default contact person will be return if no vendor contact person in 
				sample request or not contact person match
17 Apr 2004	Lester Wu		Reutrn Header Remark Field
17 March 2005	Lester Wu		Retrieve Company Name, Short Name, Address, Phone , Fax, Email
23 May 2005	Marco Chan	Enhance with Custom Vendor
=========================================================     
*/

--sp_select_SAR00006  'UCP','R040','R041','1','1','SEQ','Y'

CREATE  PROCEDURE [dbo].[sp_select_SAR00006] 

@cocde		nvarchar(6),	
@SARfm		nvarchar(20),	
@SARto		nvarchar(20),
@printDI		nvarchar(1),
@printDV		nvarchar(1),
@sort		char(3)='SEQ',
@showCnt		char(1)

AS

create table #tmp_SAR00006
(
	srh_cocde nvarchar(6),
	srh_subcde nvarchar(10),
	srh_reqno nvarchar(20),
	srh_issdat datetime,
	srh_rvsdat datetime,
	srh_venno  nvarchar(6),
	srh_venadr  nvarchar(200),
	srh_venstt  nvarchar(20),
	srh_vencty  nvarchar(6),	
	srh_venpst  nvarchar(20),
	srh_venctp  nvarchar(50),	
	srh_salrep  nvarchar(30),
	srh_cus1no  nvarchar(6),
	srh_cussmppo  nvarchar(50),
--	srh_vendeldat  nvarchar(8),
	srh_vendeldat  datetime,
	srh_rmk  nvarchar(300),
	srh_vendeldatDD nvarchar(2),
	srh_vendeldatMM  nvarchar(2),
	tmp_tel_count	int,
	tmp_fax_count	int,
	srh_tel	nvarchar(100),
	srh_fax	nvarchar(100),
	srh_srname nvarchar(30)
)


DECLARE @vci_venno nvarchar(6),
	@vci_cntphn nvarchar(30),
	@vci_cntfax nvarchar(30)

------------------------------------------------------------------------------------------------------------------------------------------------------
--Lester Wu 2005/03/03 -- Retrieve Company Name, Short Name, Address, Phone No, Fax No, Email Address, Logo Path
------------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE
@yco_conam	varchar(100),
@yco_conamc	nvarchar(100),
@yco_addr		varchar(200),
@yco_addrc	nvarchar(200),
@yco_phoneno	varchar(50),
@yco_faxno	varchar(50),

@yco_logoimgpth	varchar(100)

set @yco_conam = ''
set @yco_conamc = ''
set @yco_addr = ''
set @yco_addrc = ''

set @yco_phoneno = ''
set @yco_faxno = ''

set @yco_logoimgpth = ''


select
@yco_conam=yco_conam,
@yco_conamc=yco_conamc,
@yco_addr=yco_addr,
@yco_addrc=yco_addrc,

@yco_phoneno= yco_phoneno,
@yco_faxno = yco_faxno,
@yco_logoimgpth = yco_logoimgpth
from 
SYCOMINF(NOLOCK)
where
yco_cocde = @cocde
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

insert into #tmp_SAR00006
select 	-- SAREQHDR
	srh_cocde,		srh_subcde,	srh_reqno,		srh_issdat,
	srh_rvsdat,		srh_venno,		srh_venadr,
	srh_venstt,		srh_vencty,	srh_venpst,
	srh_venctp,	srh_salrep,		srh_cus1no,
	srh_cussmppo,	srh_vendeldat,	srh_rmk,
	srh_vendeldatDD = ltrim(str(datepart(dd,srh_vendeldat))),
	srh_vendeldatMM = ltrim(str(datepart(mm,srh_vendeldat))),
	0,0,'','',srh_srname
from 	SAREQHDR
WHERE 	srh_cocde = @cocde and srh_reqno >= @SARfm and srh_reqno <= @SARto

--select * from #tmp_SAR00006

if @ShowCnt='Y' 
begin

/*update #tmp_SAR00006 set 	srh_cntctp = vci_cntctp,
			srh_tel=vci_cntphn,
			srh_fax = vci_cntfax
from VNCNTINF
where srh_venno = vci_venno
and srh_venctp = vci_cntctp
and srh_venctp<>''
and vci_cnttyp='GENL'

update #tmp_SAR00006 set 	srh_cntctp = vci_cntctp,
			srh_tel=vci_cntphn, 
			srh_fax=vci_cntfax
from VNCNTINF
where srh_venno = vci_venno
and (	srh_venctp='' or 
	(isnull(srh_cntctp,'') = '' and isnull(srh_tel,'') = '' and isnull(srh_fax,'')='')
      )
and vci_cnttyp='GENL'
and vci_cntdef='Y'
*/



DECLARE SR_TEL_FAX_CURSOR CURSOR FOR

	select vci_venno,vci_cntphn,vci_cntfax from VNCNTINF  
	where vci_cnttyp not in ('U','M')
	--and vci_venno in (select distinct srh_venno from #tmp_SAR00006)
	order by vci_venno, vci_cnttyp,vci_cntdef,vci_seq

OPEN SR_TEL_FAX_CURSOR
FETCH NEXT FROM SR_TEL_FAX_CURSOR INTO
@vci_venno,@vci_cntphn,@vci_cntfax
	WHILE @@FETCH_STATUS = 0
	BEGIN
		update #tmp_SAR00006
		set 	srh_tel=case when len(srh_tel) > 0 then srh_tel + ' / ' + @vci_cntphn else @vci_cntphn end,
			tmp_tel_count = tmp_tel_count + 1
		where srh_venno = @vci_venno
		and tmp_tel_count < 3


		update #tmp_SAR00006
		set 	srh_fax=case when len(srh_fax) > 0 then srh_fax + ' / ' + @vci_cntfax else @vci_cntfax end,
			tmp_fax_count = tmp_fax_count + 1
		where srh_venno = @vci_venno
		and tmp_fax_count < 3

		FETCH NEXT FROM SR_TEL_FAX_CURSOR INTO
		@vci_venno,@vci_cntphn,@vci_cntfax
		
			
	END
CLOSE SR_TEL_FAX_CURSOR
DEALLOCATE SR_TEL_FAX_CURSOR

end




select
	-- VNBASINF
	a.vbi_venno, 	a.vbi_vensna,	a.vbi_vennam,
	
	-- SYSALREP
	salPeron = Isnull(yup_usrnam,''), Isnull(ssr_saltem,'') as 	'ysr_saltem',
	
	-- SYSETINF 
	--Kenny Add no 26-09-2002 (Handle Null Value Return)
	Unit = Isnull(ysi_dsc,''),

	-- CUBASINF
	cbi_cussna,	cbi_cusnam,

	-- SAREQHDR
	srh_cocde,		srh_subcde,	srh_reqno,		srh_issdat,
	srh_rvsdat,		srh_venno,		srh_venadr,
	srh_venstt,		srh_vencty,		srh_venpst,
	srh_venctp,		srh_salrep,		srh_cus1no,
	srh_cussmppo,	srh_vendeldat,	srh_rmk,
	-- Lester Wu 2004/04/17
	case when len(isnull(srh_rmk,''))>0 then 'Y' else 'N' end as 'optSrh_Rmk',
	----------------------------------------------------------------------------------------
	srh_vendeldatDD , --= ltrim(str(datepart(dd,srh_vendeldat))),
	srh_vendeldatMM, -- = ltrim(str(datepart(mm,srh_vendeldat))),
	-- SAREQDTL
	srd_reqseq,	srd_engdsc,	srd_chndsc,
	srd_cusitm,	
	case srd_itmno when '' then 
	case srd_itmnoreal when '' then 
	case srd_itmnotmp when '' then 
	case srd_itmnoven when '' then '' else srd_itmnoven end else srd_itmnotmp end else srd_itmnoreal end else srd_itmno end as 'srd_itmno' ,		
	srd_venitm,
	srd_vencol,	srd_coldsc,		srd_untcde,	
	srd_smpunt,	
	srd_smpqty,	samplesQty = str(srd_smpqty),
	srd_note,		srd_tbm
	--
	,srh_tel,srh_fax
	--	
	,case a.vbi_ventyp when 'E' then @ShowCnt else 'N' end as 'ShowCnt',
	srd_prdven,
	srd_prdsub,
	b.vbi_vensna 'prdvensna',
	@sort as '@sort',
	--2005/03/03 Lester Wu -- Retrieve Company Name , Short Name , Address, Phone, Fax, Email
	@yco_conam as 'CompName',
	@yco_addr as 'CompAddr',
	@yco_conamc as 'CompNameC',
	@yco_addrc as 'CompAddrC',
	@yco_phoneno as 'CompPhone',
	@yco_faxno as 'CompFAX',
	@yco_logoimgpth as 'CompLogo'
	--
from 	
#tmp_SAR00006
left join SAREQDTL on srh_cocde = srd_cocde and srh_reqno = srd_reqno
left join VNBASINF a on srh_venno = a.vbi_venno and a.vbi_vensts <> (case @printDV  when '0' then 'D' else '' end)
left join VNBASINF b on srd_prdven = b.vbi_venno
--left join SYSALREP on srh_srname = ysr_code
left join SYUSRPRF prf on srh_srname = prf.yup_usrid
left join SYSALREL on srh_srname=ssr_salrep
left join SYSETINF on ysi_typ = '05' and srd_smpunt = ysi_cde
left join CUBASINF on srh_cus1no = cbi_cusno
WHERE 	
a.vbi_venno is not null
and b.vbi_venno is not null
and 	srd_canflg<>'Y'
order by 
	srh_reqno,
	case @sort when 'ITM' then srd_itmno else '' end,
	case @sort when 'SEQ' then srd_reqseq else 0 end
	
drop table #tmp_SAR00006












GO
GRANT EXECUTE ON [dbo].[sp_select_SAR00006] TO [ERPUSER] AS [dbo]
GO
