/****** Object:  StoredProcedure [dbo].[sp_select_CLR00001]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CLR00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CLR00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












/************************************************************************
Description:	insert data into CLR00001
***********************************************************************
*/


CREATE     procedure [dbo].[sp_select_CLR00001]


@cad_cocde	nvarchar(6),
@cad_caordno	nvarchar(20)

 
AS

BEGIN




begin

--------------------------------------------------------------------------------------------------
select
cah_caordno,
--cah_caordsts,
isnull (case cah_caordsts when 'OPEN' then 'Open/Active' 
      else isnull(case cah_caordsts when 'WAIT' then 'Waiting For Approval'
      else isnull(case cah_caordsts when 'APPV' then 'Customer Claim Amt confirmed' 
      else isnull(case cah_caordsts when 'RELS' then 'Claim Released' 
      else isnull(case cah_caordsts when 'CANL' then ' Cancel'
      else isnull(case cah_caordsts when 'CLOS' then ' Closed' else ''end,'')end,'') end,'') end,'')end,'')  end, '')  as 'cah_caordsts',
--CONVERT(CHAR(10),cah_issdat, 23) as 'cah_issdat',
--cah_claby,
isnull (case cah_claby when 'C' then 'Customer' else isnull(case cah_claby when 'V' then 'Vendor' else '' end,'') end, '')  as 'cah_claby',
cah_cus1no 'cah_cus1no',
cah_cus2no 'cah_cus2no',
cah_venno 'cah_venno',
cah_clatyp 'cah_clatyp',
cah_rmk,
cah_custcomment,
cah_finding,
--cah_adhoc,
--isnull (case cah_adhoc when 'Y' then '(ADHOC)' else ''end,'')  as 'cah_adhoc',
cah_cacur,
cah_caamt_org,
cah_caamt_final,
--cah_cavsgrspft,
cah_catoinscur,
cah_catoinsamt,
cah_catovncur,
cah_catovnamt,
--cah_catoivncur,
--cah_catoivnamt,
--cah_catoevncur,
--cah_catoevnamt,
cah_catohkocur,
cah_catohkoamt,
CONVERT(CHAR(10),cah_upddat, 23) as 'cah_upddat',
cah_creusr,
cah_updusr,
convert (varchar(3), cad_caordseq) as 'cad_caordseq',
cad_txcocde,
cad_scordno,
convert (varchar(3), cad_scordseq) as 'cad_scordseq',
cad_popurord,
convert (varchar(3), cad_popurseq) as 'cad_popurseq',
cad_shinvno,
cad_itmno,
cad_cusitm,
cad_sccuspono,
cad_itmdsc,
cad_prdven,
cad_scpckunt,
cad_scordqty,
cad_scshpqty,
cad_sccurcde,
cad_scfcurcde,
cad_scftyprc,
convert (varchar(10), cad_caqty) as 'cad_caqty',
cad_calmtper,
cad_salcur,
cad_salamt,
cad_grspftamt,
cad_catoinscur,
cad_catoinsamt,
cad_catovncur,
cad_catovnamt,
cad_catohkocur,
cad_catohkoamt,
cad_cacur,
cad_caamt_final,
--cad_upddat,
CONVERT(CHAR(10), cad_upddat, 23) as 'cad_upddat',
cad_updusr,
cad_creusr,
cad_cocde,
cad_scftyprc,
cad_scfcurcde,
CONVERT(CHAR(10),cad_shetadat, 23) as  'cad_shetadat',
cad_rmk,
cah_caamt_org,
cah_caamt_final,
pri.cbi_cusno as 'cad_cus1no', 
pri.cbi_cussna as 'cad_cus1sna', 
sec.cbi_cusno as 'cad_cus2no',
sec.cbi_cussna as 'cad_cus2sna',
clmtyp.yct_dsc as 'cad_cltypdsc',
vbn.vbi_vensna as 'cad_vensna',
usrteam.yup_usrgrp as 'cah_updusr',
applflg1.yup_usrnam as 'cah_app1nam',
applflg2.yup_usrnam as 'cah_app2nam',
pvbn.vbi_vensna as 'cad_prdvennam',
pri.cbi_salmgt as 'cah_receiver',
'Team ' + sales.ysr_saltem as 'cah_team',
pri.cbi_srname as 'cah_saleperson',
--sales.ysr_dsc as 'cah_saleperson',
cad_prdven,
cad_prdven + '-' + pvbn.vbi_vensna as 'cad_prdvenwithnam',
case  cah_pot_val when 'V' then 'Valid' else 'Potential' end as 'cah_pot_vad',
cad_pojobord as 'cad_pojobord'

from  CAORDHDR(nolock)

left join  CAORDDTL (nolock) on  cad_caordno = @cad_caordno

left join CUBASINF pri on pri.cbi_cusno = cah_cus1no
left join VNBASINF pvbn (nolock) on pvbn.vbi_venno  = cad_prdven
left join CUBASINF sec on sec.cbi_cusno = cah_cus2no
left join SYCLMTYP clmtyp(nolock) on clmtyp.yct_cde = cah_clatyp
left join VNBASINF vbn (nolock) on vbn.vbi_venno  = cah_venno
left join SYUSRPRF usrteam (nolock) on usrteam.yup_usrid  = cah_creusr
left join SYUSRPRF applflg1 (nolock) on applflg1.yup_usrid  = cah_app1flgby
left join SYUSRPRF applflg2 (nolock) on applflg2.yup_usrid  = cah_app2flgby
left join SYSALREP sales (nolock) on sales.ysr_code1 = pri.cbi_salrep
where cah_caordno = @cad_caordno
order by cast( cad_caordseq as int) 





end
--END
end








GO
GRANT EXECUTE ON [dbo].[sp_select_CLR00001] TO [ERPUSER] AS [dbo]
GO
