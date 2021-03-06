/****** Object:  StoredProcedure [dbo].[sp_list_QUADDINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_QUADDINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_QUADDINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sp_list_QUADDINF] 

@cocde	nvarchar(5),
@qutno		nvarchar(40),
@report	nvarchar(20),
@qutseq	int

AS

declare
@cus1no	nvarchar(20),
@cus2no	nvarchar(20)

BEGIN

	select 
		@cus1no = quh_cus1no, 
		@cus2no = quh_cus2no
	from 
		QUOTNHDR
	where 
		quh_qutno = @qutno

	select 
		sqi_sheet,
		sqi_fldid,
		sqi_loc,
		qdi_value		
	from
		SYQURPTINF, QUADDINF
	where
		sqi_fldid = qdi_fldid and
		sqi_cus1no =  @cus1no and
		sqi_cus2no =  @cus2no and
		sqi_rptid = @report and
		qdi_qutseq = @qutseq and		
		qdi_qutno = @qutno

END



GO
GRANT EXECUTE ON [dbo].[sp_list_QUADDINF] TO [ERPUSER] AS [dbo]
GO
