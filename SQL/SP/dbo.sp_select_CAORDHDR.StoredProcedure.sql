/****** Object:  StoredProcedure [dbo].[sp_select_CAORDHDR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CAORDHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CAORDHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





















/************************************************************************
 Description:	Select data From CAORDHDR
***********************************************************************
*/

CREATE            procedure [dbo].[sp_select_CAORDHDR]
@cah_cocde nvarchar(6),
@cah_caordno nvarchar(20)

AS

BEGIN

--------------------------------------------------------------------------------------------------


SELECT	
cah_cocde,
cah_caordno,
cah_caordsts,
cah_claby,
cah_cus1no,
cah_cus2no,
cah_venno,
cah_clatyp,
cah_rmk,
cah_custcomment,
cah_finding,
cah_salcur,
round(cah_salttlamt,2) as 'cah_salttlamt',
cah_grspftamt,
cah_calmtamt,
cah_calmtper,
cah_caremamt,
cah_cacur,
cah_caamt_org,
cah_caamt_final,
cah_app1flg,
cah_app1flgby,
cah_app1flgdat,
cah_catoinscur,
cah_catoinsamt,
cah_catovncur,
cah_catovnamt,
cah_catohkocur,
cah_catohkoamt,
cah_app2flg,
cah_app2flgby,
cah_app2flgdat,
cah_curexrat,
cah_curexeffdat,
isnull(cbi_salmgt,'') as 'cah_salesmanger',
--isnull(cbi_srname + ' (Team ' + ysr_saltem + ') - ' + ysr_code1,'') as 'cah_salesteam' ,
isnull(cbi_srname + ' (Team ' + ysr_saltem + ')','') as 'cah_salesteam' ,
cah_creusr,
cah_updusr,
cah_credat,
cah_upddat,
cast(cah_timstp as int) as cah_timstp,
cah_claPeriod,
cah_caamt_per,
cah_clasearchby,
CAH_PAYSTS,
CAH_PAIDDAT,
CAH_SETTLE_CUS,
CAH_RCVDAT,
CAH_SETTLE_FTY,
CAH_APRVSTS,
CAH_FA_LSTUPDDAT,
cah_reason,
CAH_confclm,
CAH_acct_caamt_final,

cah_pot_val,
cah_ref_no,
cah_ref_dat,
cah_stschg_usr,
cah_stschg_dat,
cah_cmt_a,
cah_cmt_b,
cah_pay_actamt,
cah_income_actamt,
cah_pay_potamt,
cah_income_potamt,
cah_pay_upddat,
cah_income_upddat,
CAH_INCOMESTS,
cah_ClaimToInsAmt_ori,
cah_ClaimToVNAmt_ori,
cah_ClaimToHKOAmt_ori,
cah_replace,
cah_caordsts_a,			
cah_caordsts_b,
cah_season,
isnull(cah_rplno,'') as 'cah_rplno',
*

from CAORDHDR (nolock)
left join CUBASINF (nolock) on cbi_cusno = cah_cus1no
left join SYSALREP (nolock) on ysr_code1 = cbi_salrep
where	
cah_cocde = @cah_cocde and cah_caordno = @cah_caordno

END
GO
GRANT EXECUTE ON [dbo].[sp_select_CAORDHDR] TO [ERPUSER] AS [dbo]
GO
