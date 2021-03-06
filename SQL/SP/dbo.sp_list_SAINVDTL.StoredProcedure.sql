/****** Object:  StoredProcedure [dbo].[sp_list_SAINVDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SAINVDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SAINVDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Johnson Lai 
Date:		Feb 8, 2002
Description:	Select data From SAINVDTL
Parameter:	1. Company
		2. Sample Invo no
************************************************************************
Modify History
Date		By		Description
************************************************************************
12 Aug 2003	Lewis To		Add Sample Order Summary Handle 
				Alias Customer No.
1 Apr 2004	Marco Chan	Fix for hardcode sample invoice A0400025
				not to join SAORDSUM with company code
				due to this invoice has global company code problem 
				(QU->SR->SAORDSUM in UCPP, SAINV in UCP)
**************************************************************************/

CREATE procedure [dbo].[sp_list_SAINVDTL]
                                                                                                                                                                                                                                                               
@sid_cocde nvarchar(6) ,
@sid_invno nvarchar(20) 
 
AS
begin

if @sid_invno = 'A0400025'
begin

select 

'   '  as 'DEL',

sid_cocde,
sid_invno,
sid_invseq,
sid_itmno,

sid_cusitm,

sid_itmdsc,
sid_colcde,



isnull(cast(sid_pckunt as nvarchar(6)) + ' / ' + 
cast(sid_inrqty as nvarchar(10)) + ' / ' + 
cast(sid_mtrqty as nvarchar(10)) + ' / ' + 
cast(sid_cft as nvarchar(10)) + ' / ' + 
cast(sid_qutno as nvarchar(20)),'')  as 'sid_pck',
sid_pckunt,
sid_inrqty,
sid_mtrqty,
sid_cft,
sid_cuscol,
sid_cussmppo,
sid_coldsc,
sid_curcde,
sid_selprc,
sid_untcde,
sid_ttlamt,
sid_smpunt,
sid_shpqty,
sid_balfreqty,
sid_chgqty,
sid_rmk,
sid_itmtyp,
sid_venno,
sid_subcde,
sid_cusven,
sid_cussub,
sid_fcurcde,
sid_ftyprc,
sid_shpqty as 'sid_orgshpqty',
sid_balfreqty as 'sid_orgfreqty',
sid_chgqty as 'sid_orgchgqty',

sas_freqty as 'sas_freqty',
sas_cusqty - sas_shpqty as 'sas_outshpqty',
sas_freqty - sas_shpfreqty as 'sas_outfreqty',
sas_chgqty - sas_shpchgqty as 'sas_outchgqty',

isnull(cast(sid_itmno as nvarchar(20)) + ' : ' + 
cast(sid_colcde as nvarchar(30)), '')  as 'sid_itmcol',

--added by Mark Lau 20060923
sid_alsitmno,
sid_alscolcde,

sid_reqno,
sid_reqseq,
sid_qutno,
sid_qutseq,
sid_creusr

from SAINVDTL
inner join SAINVHDR on sid_cocde = sih_cocde and sid_invno = sih_invno
inner join SAORDSUM on sid_itmno = sas_itmno and sid_colcde = sas_colcde and  sas_cus1no in  (select cbi_cusno from cubasinf (nolock)  where cbi_cusno = sih_cus1no or cbi_cusali = sih_cus1no )


where                                                                                                                                                                                                                                                                 

sid_cocde = @sid_cocde and
sid_invno = @sid_invno
order by sid_invno, sid_invseq


end
else
begin

select 

'   '  as 'DEL',

sid_cocde,
sid_invno,
sid_invseq,
sid_itmno,
sid_cusitm,
sid_itmdsc,
sid_colcde,



isnull(cast(sid_pckunt as nvarchar(6)) + ' / ' + 
cast(sid_inrqty as nvarchar(10)) + ' / ' + 
cast(sid_mtrqty as nvarchar(10)) + ' / ' + 
cast(sid_cft as nvarchar(10)) + ' / ' + 
cast(sid_qutno as nvarchar(20)),'')  as 'sid_pck',
sid_pckunt,
sid_inrqty,
sid_mtrqty,
sid_cft,
sid_cuscol,
sid_cussmppo,
sid_coldsc,
sid_curcde,
sid_selprc,
sid_untcde,
sid_ttlamt,
sid_smpunt,
sid_shpqty,
sid_balfreqty,
sid_chgqty,
sid_rmk,
sid_itmtyp,
sid_venno,
sid_subcde,
sid_cusven,
sid_cussub,
sid_fcurcde,
sid_ftyprc,
sid_shpqty as 'sid_orgshpqty',
sid_balfreqty as 'sid_orgfreqty',
sid_chgqty as 'sid_orgchgqty',

sas_freqty as 'sas_freqty',
sas_cusqty - sas_shpqty as 'sas_outshpqty',
sas_freqty - sas_shpfreqty as 'sas_outfreqty',
sas_chgqty - sas_shpchgqty as 'sas_outchgqty',

isnull(cast(sid_itmno as nvarchar(20)) + ' : ' + 
cast(sid_colcde as nvarchar(30)), '')  as 'sid_itmcol',

--added by Mark Lau 20060923
sid_alsitmno,
sid_alscolcde,
sid_reqno,
sid_reqseq,
sid_qutno,
sid_qutseq,
sid_creusr



from SAINVDTL
inner join SAINVHDR on sid_cocde = sih_cocde and sid_invno = sih_invno
inner join SAORDSUM on sid_cocde = sas_cocde and sid_itmno = sas_itmno and sid_colcde = sas_colcde and  sas_cus1no in  (select cbi_cusno from cubasinf (nolock)  where cbi_cusno = sih_cus1no or cbi_cusali = sih_cus1no )


where                                                                                                                                                                                                                                                                 

sid_cocde = @sid_cocde and
sid_invno = @sid_invno
order by sid_invno, sid_invseq

end

end


GO
GRANT EXECUTE ON [dbo].[sp_list_SAINVDTL] TO [ERPUSER] AS [dbo]
GO
