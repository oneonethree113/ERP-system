/****** Object:  StoredProcedure [dbo].[sp_select_DOC_GEN_OUTPUT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_DOC_GEN_OUTPUT]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_DOC_GEN_OUTPUT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

create  PROCEDURE [dbo].[sp_select_DOC_GEN_OUTPUT]
@cocde 	nvarchar(6),
@doctyp	 nvarchar(2),
@usrid	nvarchar(30),
@output nvarchar(20) OUTPUT

AS

BEGIN  
update SYDOCCTL set ydc_seqno = 
	Case (Len(ydc_seqno+1))  
	when 1 then '0000'
	when 2 then '000'	
	when 3 then '00'	
	when 4 then '0'
	else ''
	end +
	ltrim(Str(ydc_seqno +1)),
	ydc_upddat = getdate(),
	ydc_updusr = @usrid
where ydc_cocde = @cocde and ydc_doctyp = @doctyp

if @doctyp = 'EM' or @doctyp = 'EA' or @doctyp = 'EP' or @doctyp = 'FS' 

	set @output = (select ydc_prefix+ right(year(getdate()),2)+ right('0' + RTRIM(month(getdate())),2) +ydc_seqno
	from SYDOCCTL 
	where ydc_cocde = @cocde and ydc_doctyp = @doctyp)

else

	set @output = (select ydc_prefix+ right(year(getdate()),2)+ydc_seqno
	from SYDOCCTL 
	where ydc_cocde = @cocde and ydc_doctyp = @doctyp)

END


GRANT EXECUTE ON [dbo].[sp_select_DOC_GEN_OUTPUT] TO [ERP_USER] AS [dbo]


GO
GRANT EXECUTE ON [dbo].[sp_select_DOC_GEN_OUTPUT] TO [ERPUSER] AS [dbo]
GO
