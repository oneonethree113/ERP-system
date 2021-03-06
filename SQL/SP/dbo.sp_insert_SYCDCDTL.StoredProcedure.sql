/****** Object:  StoredProcedure [dbo].[sp_insert_SYCDCDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYCDCDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYCDCDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sp_insert_SYCDCDTL] 
--------------------------------------------------------------------------------------------------------------------------------------

@idd_cocde	nvarchar(6) = ' ',
@idd_year	nvarchar(4),
@idd_cdcde	nvarchar(6),
@idd_seq	nvarchar(6),
@idd_trmcde	nvarchar(6),
@idd_cbm	nvarchar(18),
@idd_nsteril	nvarchar(18),
@idd_osteril	nvarchar(18),
@idd_hsteril	nvarchar(18),
@idd_updusr	nvarchar(30)

--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  SYCDCDTL

(
	idd_cocde,
	idd_year,
	idd_cdcde,
	idd_seq,
	idd_trmcde,
	idd_cbm,
	idd_nsteril,
	idd_osteril,
	idd_hsteril,
	idd_creusr,
	idd_updusr,
	idd_credat,
	idd_upddat

)
values
(
	' ',
	@idd_year,
	@idd_cdcde,
	@idd_seq,
	@idd_trmcde,
	@idd_cbm,
	@idd_nsteril,
	@idd_osteril,
	@idd_hsteril,
	@idd_updusr,
	@idd_updusr,
	getdate(),
	getdate()
)




GO
GRANT EXECUTE ON [dbo].[sp_insert_SYCDCDTL] TO [ERPUSER] AS [dbo]
GO
