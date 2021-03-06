/****** Object:  StoredProcedure [dbo].[sp_select_CUCNTINF_SC_BA]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUCNTINF_SC_BA]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUCNTINF_SC_BA]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Kenny Chan
Date:		17 Feb, 2002
Description:	Select data From CUCNTINF (Billing Address)
Parameter:		1. Company
		2. CUSNO
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_CUCNTINF_SC_BA]
                                                                                                                                                                                                                                                                 

@cci_cocde	nvarchar(6),
@cci_cusno	nvarchar(6) 
                                               
 
AS

begin

Select	cci_cocde,	cci_cusno,	cci_cnttyp,
	cci_cntseq,	cci_cntadr,	cci_cntstt,
	cci_cntcty,	cci_cntpst,	cci_cntctp,
	cci_cnttil,		cci_cntphn,	cci_cntfax,
	cci_cnteml,	cci_cntrmk,	cci_cntdef,
	cci_creusr,	cci_updusr,	cci_credat,
	cast(cci_timstp as int) as cci_timstp,cci_sapshcusno
                                  

from CUCNTINF
 where
                                                                                                                                                                                                                                                                 

--cci_cocde = @cci_cocde and
cci_cusno = @cci_cusno and 
cci_cnttyp = 'B'
--added by Mark Lau 20061228, SAP Implementation
and cci_delete = 'N'
order by 
cci_cntdef desc

end


GO
GRANT EXECUTE ON [dbo].[sp_select_CUCNTINF_SC_BA] TO [ERPUSER] AS [dbo]
GO
