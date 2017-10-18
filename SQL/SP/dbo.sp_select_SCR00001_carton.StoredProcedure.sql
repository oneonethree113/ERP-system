/****** Object:  StoredProcedure [dbo].[sp_select_SCR00001_carton]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCR00001_carton]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCR00001_carton]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 27/07/2003




CREATE  PROCEDURE [dbo].[sp_select_SCR00001_carton]
@cocde		nvarchar(6),	
@SCfrom		nvarchar(20),	@SCto		nvarchar(20)

AS

Select	sdc_cocde,
	sdc_ordno,
	sdc_seq,
	sdc_from = str(sdc_from),
	sdc_to = str(sdc_to),
	sdc_ttlctn,
	sdc_ttlctn_str = str(sdc_ttlctn)

From 	SCDTLCTN 
where sdc_ordno >= @SCfrom and sdc_ordno <= @SCto and sdc_cocde = @cocde








GO
GRANT EXECUTE ON [dbo].[sp_select_SCR00001_carton] TO [ERPUSER] AS [dbo]
GO
