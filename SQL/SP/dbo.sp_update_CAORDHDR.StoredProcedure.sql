/****** Object:  StoredProcedure [dbo].[sp_update_CAORDHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_CAORDHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_CAORDHDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





















/************************************************************************
Author:		Marco Chan   
Date:		26 Aug 2011
Description:	Update data From CAORDHDR
***********************************************************************
*/

CREATE            procedure [dbo].[sp_update_CAORDHDR]

@cah_cocde nvarchar(6) ,
@cah_caordno nvarchar(20) ,
@cah_caordsts nvarchar(20) ,
@CAH_CLAPERIOD nvarchar(30) ,
@CAH_CAAMT_PER nvarchar(1) ,
@CAH_CLASEARCHBY nvarchar(20) ,
@cah_claby nvarchar(6) ,
@cah_cus1no nvarchar(6) ,
@cah_cus2no nvarchar(6) ,
@cah_venno nvarchar(6) ,
@cah_clatyp nvarchar(6) ,
@cah_rmk nvarchar(1000) ,
@cah_custcomment nvarchar(1000),
@cah_finding nvarchar(1000),
@cah_salcur nvarchar(6) ,
@cah_salttlamt numeric(13,4) ,
@cah_grspftamt numeric(13,4) ,
@cah_calmtamt numeric(13,4) ,
@cah_calmtper numeric(13,4) ,
@cah_cacur nvarchar(6) ,
@cah_caamt_org numeric(13,4) ,
@cah_caamt_final numeric(13,4) ,
@cah_app1flg char(1) ,
@cah_app1flgby nvarchar(30) ,
@cah_app1flgdat datetime,
@cah_catoinscur nvarchar(6) ,
@cah_catoinsamt numeric(13,4) ,
@cah_catoVNcur nvarchar(6) ,
@cah_catoVNamt numeric(13,4) ,
@cah_catohkocur nvarchar(6) ,
@cah_catohkoamt numeric(13,4) ,
@cah_app2flg char(1) ,
@cah_app2flgby nvarchar(30) ,
@cah_app2flgdat datetime,
@cah_curexrat numeric(16,11) ,
@cah_curexeffdat datetime,
@CAH_PAYSTS nvarchar(4) ,
@CAH_PAIDDAT  datetime,
@CAH_SETTLE_CUS nvarchar(100) ,
@CAH_RCVDAT datetime,
@CAH_SETTLE_FTY nvarchar(100) ,
@CAH_APRVSTS nvarchar(1) ,
@CAH_FA_LSTUPDDAT datetime,
@CAH_Reason nvarchar(1000) ,
@CAH_confclm nvarchar(1) ,
@CAH_acct_caamt_final  numeric(13,4) ,
@cah_pot_val nvarchar(1) , 
@cah_ref_no nvarchar(30), 
@cah_ref_dat datetime, 
@cah_stschg_usr nvarchar(30), 
@cah_stschg_dat datetime, 
@cah_cmt_a nvarchar(1000), 
@cah_cmt_b nvarchar(1000), 
@cah_pay_actamt decimal(13,4), 
@cah_income_actamt decimal(13,4), 
@cah_pay_potamt decimal(13,4), 
@cah_income_potamt decimal(13,4), 
@cah_pay_upddat datetime, 
@cah_income_upddat datetime, 
@cah_INCOMESTS nvarchar(4),
@cah_ClaimToInsAmt_ori decimal(13,4), 
@cah_ClaimToVNAmt_ori decimal(13,4), 
@cah_ClaimToHKOAmt_ori decimal(13,4), 
@cah_replace nvarchar(1),
@cah_caordsts_a nvarchar(20),			
@cah_caordsts_b nvarchar(20),
@cah_season nvarchar(30),
@cah_pay_rmk nvarchar(1000),
@cah_income_rmk nvarchar(1000),
@cah_income_cur nvarchar(6) ,
@cah_pay_cur nvarchar(6) ,
@cah_rplno nvarchar(20) ,
@cah_updusr nvarchar(30)

AS

BEGIN

--------------------------------------------------------------------------------------------------


update CAORDHDR
set

cah_caordsts = @cah_caordsts,
CAH_CLAPERIOD=@CAH_CLAPERIOD,
CAH_CAAMT_PER=@CAH_CAAMT_PER,
CAH_CLASEARCHBY=@CAH_CLASEARCHBY,
cah_claby = @cah_claby,
cah_cus1no = @cah_cus1no,
cah_cus2no = @cah_cus2no,
cah_venno = @cah_venno,
cah_clatyp = @cah_clatyp,
cah_rmk = @cah_rmk,
cah_custcomment = @cah_custcomment,
cah_finding = @cah_finding,
cah_salcur = @cah_salcur,
cah_salttlamt = @cah_salttlamt,
cah_grspftamt = @cah_grspftamt,
cah_calmtamt = @cah_calmtamt,
cah_calmtper = @cah_calmtper,
cah_cacur = @cah_cacur,
cah_caamt_org = @cah_caamt_org,
cah_caamt_final = @cah_caamt_final,
cah_app1flg = @cah_app1flg,
cah_app1flgby = @cah_app1flgby,
cah_app1flgdat = @cah_app1flgdat,
cah_catoinscur = @cah_catoinscur,
cah_catoinsamt = @cah_catoinsamt,
cah_catoVNcur = @cah_catoVNcur,
cah_catoVNamt = @cah_catoVNamt,
cah_catohkocur = @cah_catohkocur,
cah_catohkoamt = @cah_catohkoamt,
cah_app2flg = @cah_app2flg,
cah_app2flgby = @cah_app2flgby,
cah_app2flgdat = @cah_app2flgdat,
cah_curexrat = @cah_curexrat,
cah_curexeffdat = @cah_curexeffdat,
CAH_PAYSTS=@CAH_PAYSTS,
CAH_PAIDDAT=@CAH_PAIDDAT,
CAH_SETTLE_CUS=@CAH_SETTLE_CUS,
CAH_RCVDAT=@CAH_RCVDAT,
CAH_SETTLE_FTY=@CAH_SETTLE_FTY,
CAH_APRVSTS=@CAH_APRVSTS,
CAH_FA_LSTUPDDAT=@CAH_FA_LSTUPDDAT,
CAH_Reason=@CAH_Reason,
CAH_confclm =  @CAH_confclm,
cah_pot_val=@cah_pot_val,
cah_ref_no=@cah_ref_no,
cah_ref_dat=@cah_ref_dat,
cah_stschg_usr=@cah_stschg_usr,
cah_stschg_dat=@cah_stschg_dat,
cah_cmt_a=@cah_cmt_a,
cah_cmt_b=@cah_cmt_b,
cah_pay_actamt=@cah_pay_actamt,
cah_income_actamt=@cah_income_actamt,
cah_pay_potamt=@cah_pay_potamt,
cah_income_potamt=@cah_income_potamt,
cah_pay_upddat=@cah_pay_upddat,
cah_income_upddat=@cah_income_upddat,
cah_INCOMESTS=@cah_INCOMESTS,
cah_ClaimToInsAmt_ori =@cah_ClaimToInsAmt_ori,
cah_ClaimToVNAmt_ori=@cah_ClaimToVNAmt_ori,
cah_ClaimToHKOAmt_ori=@cah_ClaimToHKOAmt_ori,
cah_replace=@cah_replace,
cah_caordsts_a=@cah_caordsts_a,
cah_caordsts_b=@cah_caordsts_b,
CAH_acct_caamt_final = @CAH_acct_caamt_final,
cah_season =@cah_season, 
cah_pay_rmk =@cah_pay_rmk,
cah_income_rmk=@cah_income_rmk,
cah_income_cur=@cah_income_cur,
cah_pay_cur=@cah_pay_cur,
cah_rplno = @cah_rplno,

cah_updusr = @cah_updusr,
cah_upddat = getdate()

WHERE	
cah_cocde = @cah_cocde and cah_caordno = @cah_caordno

END




















GO
GRANT EXECUTE ON [dbo].[sp_update_CAORDHDR] TO [ERPUSER] AS [dbo]
GO
