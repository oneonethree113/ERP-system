/****** Object:  StoredProcedure [dbo].[sp_list_SHINVHDR_SHM00001]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SHINVHDR_SHM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SHINVHDR_SHM00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create           procedure [dbo].[sp_list_SHINVHDR_SHM00001]

                                                                                                                                                                                                                                                               
@hiv_cocde nvarchar(6) ,
@hiv_shpno nvarchar(20),
@doctyp 	nvarchar(2),

@hiv_prctrm nvarchar(20),
@hiv_paytrm nvarchar(20),
@hiv_doctyp nvarchar(6),
@hiv_ttlamt numeric(13,4),

@hiv_ttlvol numeric(13,4),
@hiv_ttlctn numeric(13,4),

@hiv_untamt nvarchar(6),
@hiv_lcstmt nvarchar(2000),
@hih_slnonb datetime,
@hiv_exptnam nvarchar(200),
@hiv_exptaddr nvarchar(300),
@hiv_usrid nvarchar(30)

AS

declare @InvNo nvarchar(20)

update SYDOCCTL set ydc_seqno = 
	Case (Len(ydc_seqno+1))  
	when 1 then '0000'
	when 2 then '000'	
	when 3 then '00'	
	when 4 then '0'
	else ''
	end +
	ltrim(Str(ydc_seqno +1))

where ydc_cocde = @hiv_cocde and ydc_doctyp = @doctyp

select @Invno = ydc_prefix+ right(year(getdate()),2)+ydc_seqno
from SYDOCCTL 
where ydc_cocde = @hiv_cocde and ydc_doctyp = @doctyp

select @invno  as '@invno'

insert into SHINVHDR 
(
hiv_cocde,
hiv_shpno,
hiv_invno,
hiv_invdat,
hiv_prctrm,
hiv_paytrm,
hiv_doctyp,
hiv_doc,
hiv_cover,
hiv_ftrrmk,
hiv_untamt,
hiv_ttlamt,
hiv_ttlvol,
hiv_ttlctn,
hiv_bank,
hiv_aformat,
hiv_invamt,
hiv_afamt,
hiv_invsts,
hiv_lcstmt,
hiv_revisedat,
hiv_plrmk,
hiv_cargorcvdat,
hiv_exptnam,
hiv_exptaddr,
hiv_creusr,
hiv_updusr,
hiv_credat,
hiv_upddat
)
values
(
@hiv_cocde,
@hiv_shpno,
@invno,
getdate(),
@hiv_prctrm,
@hiv_paytrm,
@hiv_doctyp,
'',
'',
'',
@hiv_untamt,
@hiv_ttlamt,
@hiv_ttlvol,
@hiv_ttlctn,
'',
'2',
@hiv_ttlamt,
0,
'',
@hiv_lcstmt,
getdate(),
'',
@hih_slnonb,
@hiv_exptnam,
@hiv_exptaddr,
@hiv_usrid,
@hiv_usrid,
getdate(),
getdate()
)
/****
insert into SHSHPMRK
(
hsm_cocde,
hsm_shpno,
hsm_invno,
hsm_ordno,
hsm_shptyp,
hsm_imgnam,
hsm_imgpth,
hsm_engdsc,
hsm_engrmk,
hsm_creusr,
hsm_updusr,
hsm_credat,
hsm_upddat
)
values
(
@hiv_cocde,
@hiv_shpno,
@invno,
'',
'M',
'',
'',
'',
'',
@hiv_usrid,
@hiv_usrid,
getdate(),
getdate()

)

*****/

select  ydc_prefix+ right(year(getdate()),2)+ydc_seqno as INVNO
from SYDOCCTL 
where ydc_cocde = @hiv_cocde and ydc_doctyp = @doctyp







GO
GRANT EXECUTE ON [dbo].[sp_list_SHINVHDR_SHM00001] TO [ERPUSER] AS [dbo]
GO
