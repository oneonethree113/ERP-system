/****** Object:  StoredProcedure [dbo].[sp_select_CODYNSQL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CODYNSQL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CODYNSQL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[sp_select_CODYNSQL] 

@cocde	nvarchar(6),
@sqlseq 	int,
@usrid 	nvarchar(12)

AS

select 
cds_cocde ,
cds_usrid ,
cds_sqlseq ,
cds_sqldsc ,
cds_sqlsta ,
cds_creusr ,
cds_updusr ,
cds_credat ,
cds_upddat ,
cast(cds_timstp as int) as 'cds_timstp'
 from CODYNSQL
where 	cds_cocde = @cocde and 
	cds_usrid = @usrid and 
	cds_sqlseq between 
	(case @sqlseq when 0 then 1
	 else @sqlseq end)
	and
	(case @sqlseq when 0 then 2147483647
	 else @sqlseq end)

order by cds_sqlseq desc






GO
GRANT EXECUTE ON [dbo].[sp_select_CODYNSQL] TO [ERPUSER] AS [dbo]
GO
